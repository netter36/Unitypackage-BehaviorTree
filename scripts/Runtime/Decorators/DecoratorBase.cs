using System;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class DecoratorBase : Node
    {
        // protected int NodeCount = 0;

        protected Node Node;

        public void Add(Node node)
        {
            if (Node == null)
            {
                Node = node;
            }
            else
            {
                throw new Exception("하나의 노드만 추가 가능합니다.");
            }
        }
        
        public void Add(NodeStates nodeStates)
        {
            Add(new ActionNode(() => nodeStates));
        }

        public void Add(bool isValue)
        {
            Add(new Condition(() => isValue));
        }

        protected abstract NodeStates OnUpdate();
        
        public override NodeStates Evaluate()
        {
            var states = OnUpdate();
            return states;
        }
    }
}
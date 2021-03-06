﻿using System;
using System.Collections.Generic;

namespace BehaviorTree
{
    public abstract class CompositeBase : Node
    {
        protected int NodeCount = 0;

        protected readonly List<Node> Nodes = new List<Node>();

        public void Add(Node node)
        {
            Nodes.Add(node);
        }

        protected abstract NodeStates OnUpdate();
        protected abstract void Reset();
        
        public override NodeStates Evaluate()
        {
            var states = OnUpdate();

            if (states != NodeStates.Running)
            {
                Reset();
            }

            return states;
        }
    }
}
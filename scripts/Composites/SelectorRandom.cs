using System;

namespace BehaviorTree
{
    public class SelectorRandom : CompositeBase
    {
        private bool _isInit;

        protected override NodeStates OnUpdate()
        {
            if (!_isInit)
            {
                ShuffleChildren();
                _isInit = true;
            }

            for (var i = NodeCount; i < Nodes.Count; i++)
            {
                var node = Nodes[NodeCount];

                var states = node.Evaluate();
                if (states != NodeStates.Failure) return states;

                NodeCount++;
            }

            return NodeStates.Failure;
        }

        protected override void Reset()
        {
            ShuffleChildren();
        }

        private void ShuffleChildren()
        {
            var rng = new Random();
            var n = Nodes.Count;
            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                var value = Nodes[k];
                Nodes[k] = Nodes[n];
                Nodes[n] = value;
            }
        }
    }
}
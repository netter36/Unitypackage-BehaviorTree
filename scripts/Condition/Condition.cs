using System;

namespace BehaviorTree
{
    public class Condition : Node
    {
        private readonly Func<bool> _onCheck;

        public Condition(Func<bool> onCheck)
        {
            _onCheck = onCheck;
        }

        public override NodeStates Evaluate()
        {
            if(_onCheck != null) return _onCheck() ? NodeStates.Success : NodeStates.Failure;

            return NodeStates.Failure;
        }
    }
}
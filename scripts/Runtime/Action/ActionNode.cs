namespace BehaviorTree
{
    public class ActionNode : Node {
        public delegate NodeStates ActionNodeDelegate();

        private readonly ActionNodeDelegate _action;

        public ActionNode(ActionNodeDelegate action) {
            _action = action;
        }
        
        public override NodeStates Evaluate()
        {
            var state = _action();
            return state;
        }
    }
}
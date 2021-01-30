namespace BehaviorTree
{
    public class ReturnSuccess : DecoratorBase
    {
        protected override NodeStates OnUpdate () {
            var states = Node.Evaluate();
            if (states == NodeStates.Running) {
                return states;
            }

            return NodeStates.Success;
        }
    }
}
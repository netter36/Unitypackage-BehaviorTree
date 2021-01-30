namespace BehaviorTree
{
    public class ReturnFailure : DecoratorBase
    {
        protected override NodeStates OnUpdate () {
            var states = Node.Evaluate();
            if (states == NodeStates.Running) {
                return states;
            }

            return NodeStates.Failure;
        }
    }
}
namespace BehaviorTree
{
    public class RepeatUntilFailure : DecoratorBase
    {
        protected override NodeStates OnUpdate () {
            if (Node.Evaluate() == NodeStates.Failure) {
                return NodeStates.Failure;
            }

            return NodeStates.Running;
        }
    }
}
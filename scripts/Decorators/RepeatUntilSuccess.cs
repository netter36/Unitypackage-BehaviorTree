namespace BehaviorTree
{
    public class RepeatUntilSuccess : DecoratorBase
    {
        protected override NodeStates OnUpdate () {
            if (Node.Evaluate() == NodeStates.Success) {
                return NodeStates.Success;
            }

            return NodeStates.Running;
        }
    }
}
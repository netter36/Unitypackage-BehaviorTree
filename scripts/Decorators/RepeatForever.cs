namespace BehaviorTree
{
    public class RepeatForever : DecoratorBase
    {
        protected override NodeStates OnUpdate () {
            Node.Evaluate();
            return NodeStates.Running;
        }
    }
}
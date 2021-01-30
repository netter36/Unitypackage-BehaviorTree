namespace BehaviorTree
{
    /// <summary>
    /// Success일때 Failure를 반환하고 Failure일때 Success를 반환
    /// </summary>
    public class Inverter : DecoratorBase
    {
        protected override NodeStates OnUpdate () {
            var states = Node.Evaluate();

            switch (states) {
                case NodeStates.Success:
                    states = NodeStates.Failure;
                    break;
                case NodeStates.Failure:
                    states = NodeStates.Success;
                    break;
            }

            return states;
        }
    }
}
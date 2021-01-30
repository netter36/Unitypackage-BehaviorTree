namespace BehaviorTree
{
    /// <summary>
    ///     자식이 하나라도 SUCCESS이면 해당값을 반환하며 모두가 FAILURE일때 해당값을 반환
    /// </summary>
    public class Selector : CompositeBase
    {
        protected override NodeStates OnUpdate()
        {
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
            NodeCount = 0;
        }
    }
}
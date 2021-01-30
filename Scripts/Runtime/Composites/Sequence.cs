namespace BehaviorTree
{
    /// <summary>
    ///     자식이 하나라도 FAILURE이면 FAILURE값을 반환하며 모두가 SUCCESS이면 해당값을 반환
    /// </summary>
    public class Sequence : CompositeBase
    {
        protected override NodeStates OnUpdate()
        {
            for (var i = NodeCount; i < Nodes.Count; i++)
            {
                var node = Nodes[NodeCount];

                var states = node.Evaluate();
                if (states != NodeStates.Success) return states;

                NodeCount++;
            }

            return NodeStates.Success;
        }

        protected override void Reset()
        {
            NodeCount = 0;
        }
    }
}
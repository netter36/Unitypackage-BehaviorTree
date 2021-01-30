namespace BehaviorTree
{
    public abstract class Node
    {
        // public delegate NodeStates NodeReturn();

        // public NodeReturn nodeReturn;

        // protected NodeStates m_nodeState;

        // public NodeStates nodeState {
        //     get { return m_nodeState; }
        // }

        // public Node() {}

        public abstract NodeStates Evaluate();
    }
}
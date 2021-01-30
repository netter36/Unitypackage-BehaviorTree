using System.Collections.Generic;

namespace BehaviorTree
{
    /// <summary>
    /// 모든 자식을 실행 시키며 모든 자식이 Success일때 Success를 반환하며 하나라도 Failure일시 Failure을 반환
    /// </summary>
    public class Parallel : CompositeBase
    {
        private readonly Dictionary<Node, NodeStates> _nodeStates = new Dictionary<Node, NodeStates>();
        
        protected override NodeStates OnUpdate()
        {
            var successCount = 0;
            var failureCount = 0;

            foreach (var node in Nodes) {
                NodeStates prevStatus;
                //TODO fail일 경우에 대한 확인
                if (_nodeStates.TryGetValue(node, out prevStatus) && prevStatus == NodeStates.Success) {
                    successCount++;
                    continue;
                }

                var states = node.Evaluate();
                _nodeStates[node] = states;

                switch (states) {
                    case NodeStates.Failure:
                        failureCount++;
                        break;
                    case NodeStates.Success:
                        successCount++;
                        break;
                }
            }

            if (successCount == Nodes.Count) {
                // End();
                return NodeStates.Success;
            }

            if (failureCount > 0) {
                // End();
                return NodeStates.Failure;
            }

            return NodeStates.Running;
        }

        protected override void Reset()
        {
            _nodeStates.Clear();
        }
        
        //작업 종료
        // public override void End () {
        //     foreach (var child in Children) {
        //         child.End();
        //     }
        // }
    }
}
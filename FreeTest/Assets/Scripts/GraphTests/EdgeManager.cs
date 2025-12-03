using UnityEngine;
using UnityEngine.InputSystem;

public class EdgeManager : MonoBehaviour
{
    public GameObject edgePrefab;

    private NodeGroup firstSelectedNode;

    private void OnEnable()
    {
        NodeGroup.OnNodeGroupClicked += HandleNodeGroupClicked;
    }

    private void OnDisable()
    {
        NodeGroup.OnNodeGroupClicked -= HandleNodeGroupClicked;
    }

    void Update()
    {
        // 배경 클릭 시 선택 취소
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider == null)
            {
                Debug.Log("배경 클릭됨.");
                if (firstSelectedNode != null)
                {
                    firstSelectedNode.SetSelected(false);
                    firstSelectedNode = null;
                    Debug.Log("노드 선택이 취소되었습니다.");
                }
            }
            else
            {
                Debug.Log(hit.collider.name + " 클릭됨. 위치: " + hit.point.ToString());
            }
        }
    }

    private void HandleNodeGroupClicked(NodeGroup clickedNode)
    {
        if (firstSelectedNode == null)
        {
            // 첫 번째 노드 선택
            firstSelectedNode = clickedNode;
            firstSelectedNode.SetSelected(true);
            Debug.Log(clickedNode.name + "가 첫 번째 노드로 선택되었습니다.");
        }
        else
        {
            // 두 번째 노드 선택
            if (firstSelectedNode != clickedNode)
            {
                Debug.Log(clickedNode.name + "가 두 번째 노드로 선택되었습니다. 엣지를 생성합니다.");
                CreateEdge(firstSelectedNode, clickedNode);

                // 선택 상태 초기화
                firstSelectedNode.SetSelected(false);
                firstSelectedNode = null;
            }
        }
    }

    private void CreateEdge(NodeGroup from, NodeGroup to)
    {
        // 데이터 연결
        from.edges.Add(to);

        // 시각적 엣지 생성
        GameObject edgeObject = Instantiate(edgePrefab, Vector3.zero, Quaternion.identity);
        edgeObject.GetComponent<EdgeDrawer>().Draw(from.transform, to.transform);
    }
}
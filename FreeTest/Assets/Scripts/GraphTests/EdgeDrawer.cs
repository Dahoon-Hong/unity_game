using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class EdgeDrawer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Transform from;
    private Transform to;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    public void Draw(Transform from, Transform to)
    {
        this.from = from;
        this.to = to;
        Update(); // 초기 위치 설정
    }

    private void Update()
    {
        if (from == null || to == null) return;
        lineRenderer.SetPosition(0, from.position);
        lineRenderer.SetPosition(1, to.position);
    }
}
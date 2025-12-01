using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject nodeGroupPrefab; // Inspector 창에서 NodeGroup 프리팹을 이 변수에 할당해야 합니다.

    void Start()
    {
        if (nodeGroupPrefab == null)
        {
            Debug.LogError("StageManager에 NodeGroup 프리팹이 할당되지 않았습니다!");
            return;
        }

        for (int i = 0; i < 3; i++)
        {
            // 생성될 무작위 위치를 정합니다. (x, y 각각 -5에서 5 사이)
            float randomX = Random.Range(-5f, 5f);
            float randomY = Random.Range(-5f, 5f);
            Vector3 randomPosition = new Vector3(randomX, randomY, 0);
            // 생성 위치를 로깅
            Debug.Log("생성 위치: " + randomPosition.ToString());

            // NodeGroup 프리팹을 생성합니다.
            Instantiate(nodeGroupPrefab, randomPosition, Quaternion.identity);
        }
    }
}

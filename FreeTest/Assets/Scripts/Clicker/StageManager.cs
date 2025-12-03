using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class StageManager : MonoBehaviour
{
    public GameObject targetPrefab;
    public GameObject effectPrefab;

    private GameObject currentTarget;

    void Start()
    {
        SpawnTarget();
    }

    
    private void OnEnable()
    {
        Target.OnTargetClicked += HandleTargetClicked;
    }

    private void OnDisable()
    {
        Target.OnTargetClicked -= HandleTargetClicked;
    }

    void Update()
    {
        // if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        // {
        //     Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //     RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        //     if (hit.collider == null)
        //     {
        //         Debug.Log("배경 클릭됨. 위치: " + mousePosition.ToString());
                
        //     }
        //     else
        //     {
        //         Debug.Log(hit.collider.name + " 클릭됨. 위치: " + hit.point.ToString());
        //     }
        // }
    }

    private void HandleTargetClicked(Target target)
    {
        Debug.Log("Target Clicked!");

        //Vector2 mousePosition = Mouse.current.position.ReadValue();
        //Vector2 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        target.OnHit();

        if (effectPrefab != null)
        {
            Instantiate(effectPrefab, worldPosition, Quaternion.identity);
        }
    }

    void SpawnTarget()
    {
        if (targetPrefab == null)
        {
            Debug.LogError("Target Prefab not assigned in StageManager!");
            return;
        }
        
        if (currentTarget != null)
        {
           Destroy(currentTarget);
        }

        // For simplicity, spawning at a fixed position. 
        // This can be changed to a random position.
        currentTarget = Instantiate(targetPrefab, Vector3.zero, Quaternion.identity);
        // currentTarget.SetActive(true);

        // // Reset target's health if it's being reused
        // var targetComponent = currentTarget.GetComponent<Target>();
        // if(targetComponent != null)
        // {
        //     // This is a simple reset. A proper re-initialization might be needed.
        //     // It's better to instantiate a new prefab as we are doing.
        // }
    }
}

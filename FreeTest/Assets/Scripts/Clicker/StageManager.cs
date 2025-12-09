using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class StageManager : MonoBehaviour
{
    public GameObject targetPrefab;
    public GameObject effectPrefab;
    public ScoreDisplayController scoreDisplayController;

    private GameObject currentTarget;
    private Player player;

    [SerializeField]
    private CardSelector cardSelector;


    void Start()
    {
        player = new Player();
        player.OnLevelUp += HandleLevelUp;
        SpawnTarget();
        UpdatePlayerUI();
        cardSelector.enabled = false;
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
        
    }

    private void HandleTargetClicked(Target target, PointerEventData eventData)
    {
        Debug.Log("Target Clicked!");

        //Vector2 mousePosition = Mouse.current.position.ReadValue();
        //Vector2 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(eventData.position);

        if (scoreDisplayController != null)
        {
            scoreDisplayController.UpdateHP(target.health);
        }

        if (target.health <= 0)
        {
            player.AddExperience(1);
            UpdatePlayerUI();
            SpawnTarget();
        }

        if (effectPrefab != null)
        {
            Instantiate(effectPrefab, worldPosition, Quaternion.identity);
        }
    }

    private void HandleLevelUp()
    {
        Debug.Log("Level Up! New Level: " + player.level);
        UpdatePlayerUI();
        cardSelector.enabled=true;
    }

    private void UpdatePlayerUI()
    {
        if (scoreDisplayController != null)
        {
            scoreDisplayController.UpdateLevel(player.level);
            scoreDisplayController.UpdateXP(player.experience, player.experienceToNextLevel);
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
        var targetComponent = currentTarget.GetComponent<Target>();
        if(scoreDisplayController != null && targetComponent != null)
        {
            scoreDisplayController.UpdateHP(targetComponent.health);
        }
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

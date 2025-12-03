using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class ScoreDisplayController : MonoBehaviour
{
    private Label scoreValueLabel;
    private int currentScore = 0;

    void Start()
    {
        Debug.Log("Initialized");
        var root = GetComponent<UIDocument>().rootVisualElement;
        scoreValueLabel = root.Q<Label>("ScoreValue");
        scoreValueLabel.text = currentScore.ToString();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        scoreValueLabel.text = currentScore.ToString();
    }

    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            AddScore(100);
        }
    }
}

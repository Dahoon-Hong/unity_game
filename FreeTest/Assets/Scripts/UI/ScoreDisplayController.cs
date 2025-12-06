using UnityEngine;
using UnityEngine.UIElements;

public class ScoreDisplayController : MonoBehaviour
{
    private Label hpValueLabel;

    void Start()
    {
        Debug.Log("Initialized");
        var root = GetComponent<UIDocument>().rootVisualElement;
        //scoreValueLabel = root.Q<Label>("ScoreValue");
        //scoreValueLabel.text = currentScore.ToString();

        hpValueLabel = root.Q<Label>("HPValue");
    }

    public void UpdateHP(int hp)
    {
        if (hpValueLabel != null)
        {
            hpValueLabel.text = hp.ToString();
        }
    }
}

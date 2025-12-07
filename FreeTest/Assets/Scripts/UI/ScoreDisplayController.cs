using UnityEngine;
using UnityEngine.UIElements;

public class ScoreDisplayController : MonoBehaviour
{
    private Label hpValueLabel;
    private Label levelValueLabel;
    private Label xpValueLabel;

    void Awake()
    {
        Debug.Log("Initialized");
        var root = GetComponent<UIDocument>().rootVisualElement;
        //scoreValueLabel = root.Q<Label>("ScoreValue");
        //scoreValueLabel.text = currentScore.ToString();

        hpValueLabel = root.Q<Label>("HPValue");
        levelValueLabel = root.Q<Label>("LevelValue");
        xpValueLabel = root.Q<Label>("XPValue");
    }

    public void UpdateHP(int hp)
    {
        if (hpValueLabel != null)
        {
            hpValueLabel.text = hp.ToString();
        }
    }

    public void UpdateLevel(int level)
    {
        if (levelValueLabel != null)
        {
            levelValueLabel.text = level.ToString();
        }
    }

    public void UpdateXP(int currentXP, int nextLevelXP)
    {
        if (xpValueLabel != null)
        {
            xpValueLabel.text = $"{currentXP} / {nextLevelXP}";
        }
    }
}

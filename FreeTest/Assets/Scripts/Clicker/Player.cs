
using System;

[Serializable]
public class Player
{
    public int level = 1;
    public int experience = 0;
    public int experienceToNextLevel = 10;

    public event Action OnLevelUp;

    public void AddExperience(int amount)
    {
        experience += amount;
        if (experience >= experienceToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level++;
        experience = 0;
        experienceToNextLevel = (int)(experienceToNextLevel * 1.5f);
        OnLevelUp?.Invoke();
    }
}

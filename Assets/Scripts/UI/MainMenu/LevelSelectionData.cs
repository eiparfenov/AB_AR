using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionData : MonoBehaviour
{
    [SerializeField] private List<List<LevelData>> levels;
    public LevelData Level { get { return levels[currentSection][currentLevel]; } }


    [SerializeField] private List<GameObject> enviroments;
    public GameObject Enviroment { get { return enviroments[currentSection]; } }


    [SerializeField] private Dictionary<string, int> starsPerLevel;


    [SerializeField] private int currentSection;
    public int CurrentSection { get { return currentSection; } }


    [SerializeField] private int currentLevel;
    public int CurrentLevel { get { return currentLevel; } }

    public void SetCurrentLevel(int currentSection, int currentLevel)
    {
        this.currentLevel = currentLevel;
        this.currentSection = currentSection;
    }
    public void FinishLevel(int stars)
    {
        int currentStars = GetStars(currentSection, currentLevel);
        if (currentStars == -1)
        {
            starsPerLevel.Add(currentSection + "." + currentLevel, stars);
        }
        else
        {
            starsPerLevel[currentSection + "." + currentLevel] = Mathf.Max(stars, currentStars);
        }
            
    }
    public int GetStars(int section, int level)
    {
        int currentStars;
        if (starsPerLevel.TryGetValue(section + "." + level, out currentStars))
            return currentStars;
        else
            return -1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Test")]
public class ProgressData : ScriptableObject
{
    [SerializeField] private List<LevelData> levels;
    [SerializeField] private List<int> progressStars;
    [SerializeField] private int currentLevel;
    [SerializeField] private bool gameStarted;

    public LevelData GetCurrentLevel { get { return levels[currentLevel]; } }
    public int GetCurrentLevelID { get { return currentLevel; } }
    public bool IsGameStarted { get { return gameStarted; } }


    public void Init()
    {
        gameStarted = true;       
        foreach (LevelData levelData in levels)
        {
            progressStars.Add(-1);
        }
        currentLevel = -1;
    }

    public void Clear()
    {
        gameStarted = false;       
        progressStars.Clear();
        currentLevel = 0;
    }


    public int GetStars (int level) { 
        return progressStars[level];
    }


    public void SetCurrentLevel(int currentLevel)
    {
        this.currentLevel = currentLevel;
    }

    public void LevelFinish(int stars){
        if (progressStars[currentLevel] == -1)
        {
            progressStars[currentLevel] = stars;
        }
        else
        {
            progressStars[currentLevel] = Mathf.Max(stars, progressStars[currentLevel]);
        }
    }
}


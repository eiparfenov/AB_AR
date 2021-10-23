using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    private LevelData levelData;
    private int currentPoints;
    private int blocksCount;
    public UnityEvent OnLevelEnd;
    public int CurrentPoints { get { return currentPoints; } }
    
    public void Init(LevelData levelData)
    {
        this.levelData = levelData;
        Instantiate(levelData.LevelPrefab, transform);
        LevelBlock[] levelBlocks = GetComponentsInChildren<LevelBlock>();
        foreach (LevelBlock block in levelBlocks)
        {
            block.OnLevelBlockDie.AddListener(LevelBlockDieHandler);
        }
        blocksCount = levelBlocks.Length;
    }
    public void LevelBlockDieHandler(int points)
    {
        blocksCount -= 1;
        currentPoints += points;
        if (blocksCount == 0)
        {
            OnLevelEnd.Invoke();
        }
    }

    private void OnDestroy()
    {
        OnLevelEnd.RemoveAllListeners();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameManager : MonoBehaviour
{
    [SerializeField] private LevelData levelData;

    private BalistaController balistaController;
    [SerializeField] private LevelController levelController;
    private UIController uIController;

    private void Awake()
    {
        balistaController = FindObjectOfType<BalistaController>();
        balistaController.Init(levelData.BulletsForLevel);
        balistaController.OnLevelEnd.AddListener(LevelEndHandler);

        //levelController = FindObjectOfType<LevelController>();
        levelController.Init(levelData);
        levelController.OnLevelEnd.AddListener(LevelEndHandler);

        uIController = FindObjectOfType<UIController>();
    }

    private void LevelEndHandler()
    {
        int points = levelController.CurrentPoints;
        int stars = 0;
        for (int i = 0; i < 4; i++)
        {
            if (points > levelData.PointsForStars[i])
                stars = i;
        }
        uIController.ShowWin(points, stars);
    }
}

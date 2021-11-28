using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GlobalGameManager : MonoBehaviour
{
    [SerializeField] private ProgressData progressData;

    private BalistaController balistaController;
    [SerializeField] private LevelController levelController;
    private UIController uIController;
    private LevelData levelData;

    private void Awake()
    {
        levelData = progressData.GetCurrentLevel;
        balistaController = FindObjectOfType<BalistaController>();
        balistaController.Init(levelData.BulletsForLevel);
        balistaController.OnLevelEnd.AddListener(LevelEndHandler);

        //levelController = FindObjectOfType<LevelController>();
        levelController.Init(levelData);
        levelController.OnLevelEnd.AddListener(LevelEndHandler);

        uIController = FindObjectOfType<UIController>();
        uIController.NextLevel.AddListener(NextLevel);
        uIController.SetIsLastLevel(progressData.GetCurrentLevelID >= 17);
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
        progressData.LevelFinish(stars);
    }

    private void NextLevel()
    {
        progressData.SetCurrentLevel(progressData.GetCurrentLevelID+1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

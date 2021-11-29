using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIMainMenuController : MonoBehaviour
{

    [SerializeField] private ProgressData progressData;
     [SerializeField] private Button exitButton;
    [SerializeField] private List<UIMainMenuLevelSelectionButton> levelChoice;



    void Start()
    {
        exitButton.onClick.AddListener(ExitButtonHandler);
        if (!progressData.IsGameStarted) progressData.Init();
        int i = 0;
        foreach (UIMainMenuLevelSelectionButton choice in levelChoice){
            choice.OnLevelButtonClick.AddListener(levelChoiceButtonHandler);
            choice.setStars(progressData.GetStars(i));
            i++;
        }
    }

    private void levelChoiceButtonHandler(int level){
        progressData.SetCurrentLevel(level);
        SceneManager.LoadScene ("SampleScene");
    }

    void Update()
    {
        
    }

    private void ExitButtonHandler()
    {
        progressData.Clear();
        // UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button restartMenuButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button homeButton;
    [SerializeField] private Button homeMenuButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Button menuButton;

    [SerializeField] private WinUI winUI;

    private bool lastLevel;
    public void SetIsLastLevel(bool lastLevel){this.lastLevel = lastLevel;}

    public UnityEvent NextLevel;

    private void Awake()
    {
        this.gameObject.transform.Find("GameUI").gameObject.transform.Find("Menu").gameObject.SetActive(true);

        restartButton.onClick.AddListener(RestartButtonHandler);
        homeButton.onClick.AddListener(HomeButtonHandler);

        menuButton.onClick.AddListener(MenuButtonHandler);
        playButton.onClick.AddListener(PlayButtonHandler);

        restartMenuButton.onClick.AddListener(RestartButtonHandler);
        homeMenuButton.onClick.AddListener(HomeButtonHandler);

        nextButton.onClick.AddListener(NextButtonHandler);
    }
    private void RestartButtonHandler()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void HomeButtonHandler()
    {
        SceneManager.LoadScene("StartScene");
    }

    private void MenuButtonHandler()
    {
        menuButton.gameObject.SetActive(false);
        this.gameObject.transform.Find("MenuUI").gameObject.SetActive(true);
    }

    private void PlayButtonHandler()
    {
        menuButton.gameObject.SetActive(true);
        this.gameObject.transform.Find("MenuUI").gameObject.SetActive(false);
    }

    private void NextButtonHandler()
    {
        NextLevel.Invoke();
    }
    private void OnDestroy()
    {
        NextLevel.RemoveAllListeners();
    }


    public void ShowWin(int points, int stars)
    {
        menuButton.gameObject.SetActive(false);
        winUI.gameObject.SetActive(true);
        if(lastLevel)
            winUI.gameObject.transform.Find("Next").gameObject.SetActive(false);
        winUI.Init(points, stars);
    }
}

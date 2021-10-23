using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button restartButton1;
    [SerializeField] private Button restartButton2;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button homeButton;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button pauseButton;

    [SerializeField] private WinUI winUI;

    private void Awake()
    {
        restartButton1.onClick.AddListener(RestartButtonHandler);
    }
    private void RestartButtonHandler()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ShowWin(int points, int stars)
    {
        winUI.gameObject.SetActive(true);
        winUI.Init(points, stars);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentManager : MonoBehaviour
{
    [SerializeField] private GameObject Level;

    private GameObject currentLevel;
    private int boxCount = 9;
    private bool started = false;
    
    private void RestartLevel()
    {
        Destroy(currentLevel);
        currentLevel = Instantiate(Level, transform);
        boxCount = 9;
    }

    public void BoxDownHandler()
    {
        boxCount -= 1;
        if (boxCount == 0)
        {
            RestartLevel();
        }
    }
    
    public void StartLevel()
    {
        if (!started)
        {
            currentLevel = Instantiate(Level, transform);
            boxCount = 9;
            Destroy(GameObject.Find("emulator_ground_plane"));
            started = true;
        }
    }
}

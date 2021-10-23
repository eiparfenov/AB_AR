using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinUI : MonoBehaviour
{
    [SerializeField] private GameObject[] stars;
    [SerializeField] private TextMeshProUGUI text;
    public void Init(int points, int stars)
    {
        for (int i = 0; i < stars; i++)
        {
            this.stars[i].SetActive(true);
        }
        text.text = points.ToString();
    }
}

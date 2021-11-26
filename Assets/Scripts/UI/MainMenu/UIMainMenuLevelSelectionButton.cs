using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Button))]
public class UIMainMenuLevelSelectionButton : MonoBehaviour
{
    [SerializeField] private int section;
    [SerializeField] private int level;

    public UnityEvent<int, int> OnLevelButtonClick;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(ButtonClickHandler);
    }
    private void ButtonClickHandler()
    {
        OnLevelButtonClick.Invoke(section, level);
    }
    private void OnDestroy()
    {
        OnLevelButtonClick.RemoveAllListeners();
    }
}

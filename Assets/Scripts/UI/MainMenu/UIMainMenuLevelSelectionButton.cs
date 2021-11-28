using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Button))]
public class UIMainMenuLevelSelectionButton : MonoBehaviour
{
    [SerializeField] private int level;


    public UnityEvent<int> OnLevelButtonClick;

    private void Awake()
    { 
        GetComponent<Button>().onClick.AddListener(ButtonClickHandler);
    }

    public void setStars(int stars){
        int i = 1;
        // for(int i = 1; i <= stars; i++){
        //     transform.Find("star"+i).active = true;
        // }
        foreach (Transform child in transform)
        {
            Image star = child.gameObject.GetComponent<Image>();
            if(stars == -1)
            {
                star.gameObject.SetActive(false);
            }
            else
            {
                star.gameObject.SetActive(true);
                if (i <= stars){
                    star.sprite = Resources.Load<Sprite>( "UI/Filledstardraft" );
                }else{
                    star.sprite = Resources.Load<Sprite>( "UI/Hollowstardraft" );
                }
            }
            i++;
        }
    }

    private void ButtonClickHandler()
    {
        OnLevelButtonClick.Invoke(level-1);
    }

    private void OnDestroy()
    {
        OnLevelButtonClick.RemoveAllListeners();
    }
}

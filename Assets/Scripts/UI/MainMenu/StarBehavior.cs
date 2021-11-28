using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarBehavior : MonoBehaviour
{
    // public void setSprite(bool isFilled){
    //     if(isFilled)
    //         GetComponent().sprite.texture = Resources.Load<Texture2D>( "UI/StarFilled" );
    //     else
    //         GetComponent().sprite.texture = Resources.Load<Texture2D>( "UI/StarHollow" );
    // }
    public void setSprite(bool isFilled){
        if(isFilled)
            GetComponent<Image>().color = new Color32(246,255,15,255);
        else
            GetComponent<Image>().color = new Color32(150,150,150,255);
    }
    // public void setActive(bool active){
    //     GetComponent<Image>().gameObject.SetActive(active);
    // }
}

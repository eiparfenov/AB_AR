using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BulletBehaviourActivator : MonoBehaviour, IPointerClickHandler
{
    private BulletBehaviourBase bulletBehaviour;
    public void Activate(BulletBehaviourBase bulletBehaviour)
    {
        this.bulletBehaviour = bulletBehaviour;
        gameObject.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(bulletBehaviour){
            bulletBehaviour.ActivationHandler();
        }
        gameObject.SetActive(false);
    }
}

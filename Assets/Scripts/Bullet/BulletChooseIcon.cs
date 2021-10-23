using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BulletChooseIcon : MonoBehaviour, IPointerClickHandler
{
    private int id;
    public UnityEvent<int> OnClick;
    public void Init(int id)
    {
        this.id = id;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick.Invoke(id);
    }
}

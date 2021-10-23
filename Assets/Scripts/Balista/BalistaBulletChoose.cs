using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalistaBulletChoose : MonoBehaviour
{
    [SerializeField] private GameObject buttonPref;
    [SerializeField] private List<BulletData> bulletDatas;
    [SerializeField] private RectTransform selecter;

    private int nextBulletId = 0;
    public BulletData NextBullet 
    { 
        get
        {
            BulletData nextBullet = bulletDatas[nextBulletId];
            bulletDatas.RemoveAt(nextBulletId);
            nextBulletId = 0;
            fill();
            return nextBullet;
        } 
    }
    public bool IsNextBullet { get { return bulletDatas.Count > 0; } }

    public void Init(List<BulletData> bulletDatas)
    {
        this.bulletDatas = bulletDatas;
        fill();
    }
    private void SelectChangedHandler(int newId)
    {
        nextBulletId = newId;
        SetSelecterPosition();
    }
    private void fill()
    {
        foreach (BulletChooseIcon icon in transform.GetComponentsInChildren<BulletChooseIcon>())
        {
            Destroy(icon.gameObject);
        }
        for (int i = 0; i < bulletDatas.Count; i++)
        {
            GameObject newButton = Instantiate(buttonPref, transform.GetChild(0));
            newButton.GetComponent<BulletChooseIcon>().Init(i);
            newButton.GetComponent<BulletChooseIcon>().OnClick.AddListener(SelectChangedHandler);
            newButton.GetComponent<Image>().sprite = bulletDatas[i].BulletSprite;
        }
        SetSelecterPosition();
    }
    private void SetSelecterPosition()
    {
        selecter.anchoredPosition = Vector2.down * 170 * nextBulletId;
        if (bulletDatas.Count == 0)
            selecter.gameObject.SetActive(false);
    }
    private void Start()
    {
        fill();
    }
}

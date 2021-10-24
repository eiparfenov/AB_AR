using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BalistaController : MonoBehaviour
{
    private BalistaBullet balistaBullet;
    private BalistaTraectoryPrediction balistaTraectoryPrediction;
    private BalistaBulletChoose balistaBulletChoose;
    private BalistaShooter balistaShooter;
    private BulletBehaviourActivator bulletBehaviourActivator;

    private BulletData currentBullet;

    public UnityEvent OnLevelEnd;

    public void Init(List<BulletData> bulletDatas)
    {
        balistaShooter = GetComponentInChildren<BalistaShooter>();
        balistaShooter.OnShootCompleted.AddListener(ShootCompletedHandler);
        balistaShooter.OnShootStarted.AddListener(ShootStartedHandler);

        balistaTraectoryPrediction = GetComponentInChildren<BalistaTraectoryPrediction>();

        currentBullet = bulletDatas[0];
        SetBullet(bulletDatas[0]);
        bulletDatas.RemoveAt(0);

        balistaBulletChoose = FindObjectOfType<BalistaBulletChoose>();
        balistaBulletChoose.Init(bulletDatas);

        bulletBehaviourActivator = FindObjectOfType<BulletBehaviourActivator>();
        bulletBehaviourActivator.gameObject.SetActive(false);
    }
    private void BalistaBulletMoveHandler()
    {
        balistaTraectoryPrediction.DrawTraectory(balistaBullet.Position);
    }
    private void BalistaBulletDropHandler()
    {
        if (balistaShooter.ShootAble(balistaBullet.Position))
            balistaShooter.Shoot(balistaBullet.Position, currentBullet, balistaBullet.gameObject);
        else
            balistaBullet.transform.localPosition = balistaTraectoryPrediction.transform.localPosition;
    }
    private void ShootCompletedHandler()
    {
        if (balistaBulletChoose.IsNextBullet)
            SetBullet(balistaBulletChoose.NextBullet);
        else
            StartCoroutine(FinishLevel());
    }
    private void ShootStartedHandler(BulletBehaviourBase bulletBehaviour)
    {
        bulletBehaviourActivator.Activate(bulletBehaviour);
    }
    private void SetBullet(BulletData bulletData)
    {
        Vector3 spawningOffset = balistaTraectoryPrediction.transform.position;
        GameObject currentBullet = Instantiate(bulletData.BulletPref, spawningOffset, Quaternion.identity, balistaTraectoryPrediction.transform.parent);
        balistaBullet = currentBullet.AddComponent<BalistaBullet>();
        balistaBullet.OnBalistaBulletMove.AddListener(BalistaBulletMoveHandler);
        balistaBullet.OnBalistaBulletDrop.AddListener(BalistaBulletDropHandler);
        balistaTraectoryPrediction.SetParams(bulletData.G, bulletData.V0);
        this.currentBullet = bulletData;
    }
    private void Update()
    {
        if (balistaBullet.Aiming && balistaShooter.ShootAble(balistaBullet.Position))
            balistaTraectoryPrediction.DrawTraectory(balistaBullet.Position);
        else
            balistaTraectoryPrediction.HidePoints();
    }
    private IEnumerator FinishLevel()
    {
        yield return new WaitForSeconds(5);
        OnLevelEnd.Invoke();
    }
    private void OnDestroy()
    {
        OnLevelEnd.RemoveAllListeners();
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPredict : MonoBehaviour
{
    [SerializeField] private int traectoryPointsCount;
    [SerializeField] private float traectoryPointDistanceTime;
    [SerializeField] private GameObject traectoryPoint;

    private float speedAmplifier;
    private ShootingPlane shootingPlane;
    private List<GameObject> traectoryPoints;
    private void Awake()
    {
        shootingPlane = transform.GetComponentInParent<ShootingPlane>();
        shootingPlane.OnStopTargeting.AddListener(StopTargetingHandler);
        traectoryPoints = new List<GameObject>();
        for (int i = 0; i < traectoryPointsCount; i++)
        {
            traectoryPoints.Add(Instantiate(traectoryPoint, transform));
            traectoryPoints[i].SetActive(false);
        }
        speedAmplifier = 2f / transform.parent.GetComponentInChildren<ShootingShow>().TrowingDuration;
    }
    void Update()
    {
        if(shootingPlane.IsTargeting)
        {
            Vector3 v0 = shootingPlane.TargetPosition - Vector3.forward * 5;
            v0 = v0 * speedAmplifier * (-1f);
            PlaceTraectroyPoints(v0);
        }
    }
    private void PlaceTraectroyPoints(Vector3 v0)
    {
        Vector3 g = transform.InverseTransformDirection(Vector3.down) * 10;
        for (int i = 0; i < traectoryPointsCount; i++)
        {
            float t = (i + 1f) * traectoryPointDistanceTime;
            traectoryPoints[i].transform.localPosition = v0 * t + g * t * t / 2f;
            traectoryPoints[i].SetActive(true);
        }
    }
    private void StopTargetingHandler()
    {
        
        for (int i = 0; i < traectoryPointsCount; i++)
        {
            traectoryPoints[i].SetActive(false);
        }
    }
}

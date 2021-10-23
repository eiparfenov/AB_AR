using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingShow : MonoBehaviour
{
    [SerializeField] private GameObject objToShoot;
    [SerializeField] private float trowingDuration;
    [Space]
    [SerializeField] private GameObject physicalObjectToThrow;
    public float TrowingDuration { get { return trowingDuration; } }

    private Transform trToShoot;
    private ShootingPlane shootingPlane;
    private bool shootable = true;

    

    private void Awake()
    {
        trToShoot = objToShoot.transform;
        shootingPlane = GetComponentInParent<ShootingPlane>();
        shootingPlane.OnLaunch.AddListener(LaunchHandler);
    }

    private void Update()
    {
        if (shootable)
        {
            trToShoot.localPosition = shootingPlane.TargetPosition;
            objToShoot.SetActive(shootingPlane.IsTargeting);
        }
    }

    private void LaunchHandler()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        shootable = false;
        objToShoot.SetActive(true);
        Vector3 startPosition = trToShoot.localPosition;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / trowingDuration;
            trToShoot.localPosition = Vector3.Lerp(startPosition, Vector3.forward * 5, t * t);
            yield return null;
        }
        GameObject bullet = Instantiate(physicalObjectToThrow, trToShoot.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(trToShoot.localPosition - startPosition) * 2f / trowingDuration, ForceMode.VelocityChange);
        shootable = true;
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}

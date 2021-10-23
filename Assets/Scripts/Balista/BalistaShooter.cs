using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BalistaShooter : MonoBehaviour
{
    [SerializeField] private float minShootDistance;
    public UnityEvent OnShootCompleted;
    public bool ShootAble(Vector3 bulletPosition)
    {
        bulletPosition = transform.localPosition - bulletPosition;
        return bulletPosition.magnitude >= minShootDistance;
    }
    public void Shoot(Vector3 position, BulletData bulletData, GameObject bullet)
    {
        Destroy(bullet.GetComponent<BalistaBullet>());
        StartCoroutine(ShootCorutine(transform.localPosition - position, bulletData, bullet.transform));
    }
    private IEnumerator ShootCorutine(Vector3 tension, BulletData bulletData, Transform bullet)
    {
        float dt = 2f * tension.magnitude / bulletData.V0; 
        float progress = 0;
        Vector3 start = transform.localPosition - tension;
        Vector3 end = transform.localPosition;
        while(progress < 1f)
        {
            progress += Time.deltaTime / dt;
            bullet.localPosition = Vector3.LerpUnclamped(start, end, progress * progress);
            yield return null;
        }
        GameObject bulletGameObject = bullet.gameObject;
        Rigidbody bulletRigidbody = bulletGameObject.AddComponent<Rigidbody>();
        bulletRigidbody.mass = bulletData.Mass;
        bulletRigidbody.AddForce(transform.TransformDirection(end - start) * bulletData.V0, ForceMode.VelocityChange);
        bulletRigidbody.useGravity = false;
        bulletGameObject.AddComponent<BulletMainBehaviour>().Init(bulletData.G);
        bullet.parent = null;
        yield return new WaitForSeconds(1f);
        OnShootCompleted.Invoke();
    }

    private void OnDestroy()
    {
        OnShootCompleted.RemoveAllListeners();
    }
}

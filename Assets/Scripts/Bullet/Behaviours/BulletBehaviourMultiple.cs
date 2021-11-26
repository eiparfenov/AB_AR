using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviourMultiple : BulletBehaviourBase
{
    [SerializeField] private float awayVelocityChange;
    public override void ActivationHandler()
    {
        Spawn(transform.right);
        Spawn(-transform.right);
    }
    
    private void Spawn(Vector3 offset)
    {
        offset = offset.normalized / 2f;
        GameObject spawned = Instantiate(gameObject, transform.position + offset, Quaternion.identity);

        BulletMainBehaviour bulletMainBehaviour = GetComponent<BulletMainBehaviour>();
        BulletMainBehaviour spawnedBulletMainBehaviour = spawned.GetComponent<BulletMainBehaviour>();
        spawnedBulletMainBehaviour.Init(bulletMainBehaviour.G, bulletMainBehaviour.LifeTime, bulletMainBehaviour.Damage);
        spawnedBulletMainBehaviour.InvokeOnDestroy = false;

        Rigidbody spawnedRb = spawned.GetComponent<Rigidbody>();
        Rigidbody rb = GetComponent<Rigidbody>();
        spawnedRb.velocity = rb.velocity;
        spawnedRb.AddForce((spawned.transform.position - transform.position).normalized * awayVelocityChange, ForceMode.VelocityChange);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviourExplosive : BulletBehaviourBase
{
    [SerializeField] private float explosionRadious;
    [SerializeField] private float explosionForce;
    public override void ActivationHandler()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadious);
        foreach (var collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb)
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadious);
        }
    }
}

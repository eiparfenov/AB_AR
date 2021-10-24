using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviourAcceleration : BulletBehaviourBase
{
    [SerializeField] private float accelerationTime;
    [SerializeField] private float acceleration;
    public override void ActivationHandler()
    {
        StartCoroutine(Accelerate());
    }

    private IEnumerator Accelerate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        float t = accelerationTime;
        while (t > 0)
        {
            rb.AddForce(rb.velocity.normalized * acceleration, ForceMode.Acceleration);
            t -= Time.deltaTime;
            yield return null;
        }
    }
}

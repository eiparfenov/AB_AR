using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMainBehaviour : MonoBehaviour
{
    private float g;
    private Rigidbody rb;
    
    public void Init(float g)
    {
        this.g = g;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.AddForce(Vector3.down * g, ForceMode.Acceleration);
    }
    private void Update()
    {
        if (transform.position.y < 0 && rb.velocity.y < 0)
        {
            Destroy(gameObject);
        }
    }
}

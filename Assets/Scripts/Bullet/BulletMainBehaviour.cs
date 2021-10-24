using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletMainBehaviour : MonoBehaviour
{
    private float g;
    private Rigidbody rb;
    private float lifeTime;
    public bool InvokeOnDestroy = true;
    public UnityEvent OnBulletDestroy = new UnityEvent();
    public float G { get { return g; } }
    public float LifeTime { get { return lifeTime; } }
    
    public void Init(float g, float lifeTime)
    {
        this.g = g;
        this.lifeTime = lifeTime;
        StartCoroutine(DieAfterTime());
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.AddForce(Vector3.down * g, ForceMode.Acceleration);
    }
    private IEnumerator DieAfterTime()
    {
        yield return new WaitForSeconds(lifeTime);
        
        Destroy(gameObject);
    }
    private void Update()
    {
        if (transform.position.y < 0 && rb.velocity.y < 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        if(InvokeOnDestroy)
            OnBulletDestroy.Invoke();
        OnBulletDestroy.RemoveAllListeners();
    }
}

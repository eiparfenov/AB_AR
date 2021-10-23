using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAfterTime : MonoBehaviour
{
    [SerializeField] private float lifeTime;

    private void Start()
    {
        StartCoroutine(WaitForDie());
    }
    private IEnumerator WaitForDie()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(this.gameObject);
    }
}

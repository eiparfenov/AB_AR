using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBlockDieAfterTime : MonoBehaviour
{
    [SerializeField] private float lifeTime;

    private void Start()
    {
        StartCoroutine(DieAfterTime(lifeTime));
    }
    private IEnumerator DieAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}

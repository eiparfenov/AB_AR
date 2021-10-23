using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDown : MonoBehaviour
{
    void Update()
    {
        if(transform.localPosition.y < -10f)
        {
            FindObjectOfType<EnviromentManager>().BoxDownHandler();
            Destroy(gameObject);
        }
    }
}

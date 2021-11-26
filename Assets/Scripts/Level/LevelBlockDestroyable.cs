using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBlockDestroyable : MonoBehaviour
{
    [SerializeField] private GameObject afterDie;

    [SerializeField] private float maxHP;
    private float hp;

    public void Start()
    {
        hp = maxHP;
    }
    public void Hit(float damage)
    {
        hp -= damage;
        if (hp<0)
        {
            Instantiate(afterDie, transform.position, transform.rotation, transform.parent);
            Destroy(gameObject);
        }
    }
}

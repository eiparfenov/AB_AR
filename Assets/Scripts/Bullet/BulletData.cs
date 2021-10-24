using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Custom/Bullet", fileName = "new bullet")]
public class BulletData : ScriptableObject
{
    [SerializeField] private float v0;
    [SerializeField] private float g;
    [SerializeField] private float mass;
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private Sprite bulletSprite;

    public float V0 { get { return v0; } }
    public float G { get { return g; } }
    public float Mass { get { return mass; } }
    public GameObject BulletPref { get { return bulletPref; } }
    public Sprite BulletSprite { get { return bulletSprite; } }
}

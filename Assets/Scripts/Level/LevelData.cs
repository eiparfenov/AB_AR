using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new level", menuName = "Custom/Level")]
public class LevelData : ScriptableObject
{
    [SerializeField] private List<BulletData> bulletsForLevel;
    [SerializeField] private GameObject levelPrefab;
    [SerializeField] private int[] pointsForStars;

    public List<BulletData> BulletsForLevel { get { return new List<BulletData>(bulletsForLevel); } }
    public GameObject LevelPrefab { get { return levelPrefab; } }
    public int[] PointsForStars { get { return pointsForStars; } }
}

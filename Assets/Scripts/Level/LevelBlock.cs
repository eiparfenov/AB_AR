using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelBlock : MonoBehaviour
{
    [SerializeField] private int pointsForBlock;
    public UnityEvent<int> OnLevelBlockDie;

    private void Update()
    {
        if(transform.localPosition.y < 0f) 
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        OnLevelBlockDie.Invoke(pointsForBlock);
        OnLevelBlockDie.RemoveAllListeners();
    }
}

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
            OnLevelBlockDie.Invoke(pointsForBlock);
            Destroy(gameObject);
            print('1');
        }
    }
    private void OnDestroy()
    {
        OnLevelBlockDie.RemoveAllListeners();
    }
}

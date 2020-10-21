using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventAnimationHelper : MonoBehaviour
{
    [SerializeField] private EnemyBase parent;
    
    public void CheckHit()
    {
        parent.CheckHit();
    }
    
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class NavAnimation : MonoBehaviour
{

    [SerializeField] private Animator animator = null;
    [SerializeField] private NavMeshAgent navAgent = null;

    // Update is called once per frame
    private void Update()
    {
        var spd = navAgent.desiredVelocity.magnitude / navAgent.speed;
        animator.SetFloat("Speed", spd);

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class Movement : MonoBehaviour
{

    NavMeshAgent agent;
    Transform followed;
    readonly WaitForSeconds delay = new WaitForSeconds(0.1f);
    bool isRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false; // For quick rotation
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.velocity.magnitude != 0) transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);
        if(followed != null)
        {
            //RotateTowardTarget(); //cant add rotation in chek, needs to be done everyfame else slow takes too long to rotate.
            if (isRunning == false)
            {

                StartCoroutine(Following(followed)); //OPTIMIZED :3 
            }

        }

    }

    private IEnumerator Following(Transform followed)
    {
        isRunning = true;

        agent.SetDestination(followed.position);
        yield return delay;
        isRunning = false;

    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void Follow(Clickable looking)
    {
        followed = looking.transform;
        agent.updateRotation = false;
        agent.stoppingDistance = looking.range * 0.9f;
    }
    
    public void UnFollow()
    {
        followed = null;
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
    }

    void RotateTowardTarget()
    {
        //Character rotates faster when rotate then when normal moving, maybe fix? later
        Vector3 dir = (followed.position - transform.position).normalized; //return only direction vector;
        Quaternion lookR = Quaternion.LookRotation(new Vector3(dir.x, 0f, dir.z));//dont want to look up or down only rotate on xz axis
        transform.rotation = Quaternion.Slerp(transform.rotation, lookR, Time.deltaTime *5f);
    }
}

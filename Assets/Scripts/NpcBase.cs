using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcBase : MonoBehaviour
{

    public Transform[] points;
    public WaitForSeconds wait = new WaitForSeconds(1.5f);
    private bool isRunning = false;
    private int destPoints = 0;
    private NavMeshAgent agent;
   
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        

    }

    // Update is called once per frame
    void Update()
    {

        if (isRunning == false)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f) // if npc close to point, will stop for wait second  before walking to next
            {
                
                StartCoroutine(Pause()); 
                

            }
        }

    }   

    private IEnumerator Pause()
    {
        isRunning = true;
        yield return wait;
        isRunning = false;
        GoNext();
    }
    void GoNext()
    {
        if (points.Length == 0)
        {
            return;
        }

        agent.destination = points[destPoints].position;
        destPoints = (destPoints + 1) % points.Length;
    }
}

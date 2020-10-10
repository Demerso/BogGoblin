using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    [Header("Stats")]
    // Start is called before the first frame update
    public float attackD;
    public float attackRate;
    public Camera cam;
    private float nextAttack;
    private NavMeshAgent navMeshAgent;
    private Animator anim;
    private const float rotSpeed = 20f;
    
    private Transform targetedEnemy;
    private bool enemyClicked;
    private bool walking;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        navMeshAgent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetButtonDown("Fire2"))
        {
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    targetedEnemy = hit.transform;
                    enemyClicked = true;
                }
                else
                {
                    walking = true;
                    enemyClicked = false;
                    navMeshAgent.isStopped = false;
                    //navMeshAgent.SetDestination(hit.point);
                    InstantTurn(hit.point);

                    

                }
            }
        }

        if (enemyClicked)
        {
           // MoveAndAttack();
        }
        if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            walking = false;
        }
        else
        {
            walking = true;
        }
        //anim.SetBool("isWalking",walking);
        
    }
   
    void MoveAndAttack()
    {
        if(targetedEnemy == null)
        {
            return;
        }
        navMeshAgent.destination = targetedEnemy.position;

        if (navMeshAgent.remainingDistance > attackD)
        {
            navMeshAgent.isStopped = false;
            walking = true;
        }
        else
        {
            transform.LookAt(targetedEnemy);
            Vector3 dirtToAttack = targetedEnemy.transform.position - transform.position;

            if (Time.time > nextAttack)
            {
                nextAttack = Time.time + attackRate;
            }
            navMeshAgent.isStopped = true;
            walking = false;
        }
    }
    void InstantTurn(Vector3 dest)
    {
        if ((dest - transform.position).magnitude < 0.1) return;

        Vector3 dir = (dest - transform.position).normalized;
        Quaternion qD = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, qD, Time.deltaTime * rotSpeed);
    }
}

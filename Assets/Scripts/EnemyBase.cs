using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    public float aggroR = 8f;
    public float attackRange = 4f;
    public float attackRate = 3f;
    public Transform player;
    private NavMeshAgent agent;
    private WaitForSeconds nextAttack = new WaitForSeconds(1.5f);//waiting time after attack
    private bool aggroed = false;
    private bool isRunning = false;
    private NpcBase basic;
    [SerializeField] private Animator animator;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        //agent.stoppingDistance = attackRange * 0.9f;
        //CANNOT CHANGE STOPPING DISTANCE BECAUSE WILL CHANGE NPC MOVEMENT ASWELL 
        basic = GetComponent<NpcBase>();
    }


    // Update is called once per frame
    void Update()//bad code can optimize for sure 
    {
        float distance = Vector3.Distance(player.position, this.transform.position);
        if(isRunning == false)
        {
            if (distance <= aggroR) //if aggro will never stop chase can probably put a distance where if too far , return to closest point in npc mvt cycle
            {
                aggroed = true;
            }
            if (aggroed == true)
            {
                agent.SetDestination(player.position);
            }
            if (distance <= attackRange*0.9f) //if player in attack range, attack and stop for nextAttack Time
            {
                
                Debug.Log("Attacked");
                animator.Play("Attack");
                StartCoroutine(Wait());

            }
            
        }
        
      

    }

    private IEnumerator Wait()
    {
        isRunning = true;
        agent.isStopped = true;
        yield return nextAttack;
        agent.isStopped = false;
        isRunning = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aggroR);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class InteractableEnemy : Clickable
{


    public float hp = 50f;
    public GameObject receiveP;

    public Health health;

    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        base.Start();
        health.onDeath.AddListener(Die);
    }

    // Update is called once per frame


    public override void interact()
    {
       
       if (joueur.Attack())
        {
           
            if (joueur.melee == false)
            {
                Debug.Log("okay");
                joueur.shot.SetPosition(0, joueur.shootP.position);
                joueur.shot.SetPosition(1, receiveP.transform.position);
                StartCoroutine(shoot());
               
                
            }
            else
            {
                joueur.animator.SetTrigger(joueur.animName);
                health.TakeDmg(joueur.dmg);
            }
        }


    }
    private IEnumerator shoot()
    {
        joueur.animator.SetTrigger(joueur.animName);
        yield return new WaitForSeconds(0.2f);
    
        joueur.shot.enabled = true;
        joueur.aud.Play();
        health.TakeDmg(joueur.dmg);
        yield return new WaitForSeconds(0.25f);
        joueur.shot.enabled = false;
    }

    private void Die()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<EnemyBase>().enabled = false;
        GetComponent<NpcBase>().enabled = false;
        GetComponent<InteractableEnemy>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        animator.SetTrigger("Die");
    }
  
}

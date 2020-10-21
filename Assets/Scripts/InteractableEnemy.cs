﻿using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class InteractableEnemy : Clickable
{


    public float hp = 50f;
    public GameObject receiveP;

    [SerializeField] private Animator animator;
    [SerializeField] private QuestManager questManager;
    
    // Start is called before the first frame update
    private void Start()
    {
        base.Start();
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
                joueur.animator.Play(joueur.animName);
                takeDmg();
            }
        }


    }
    private IEnumerator shoot()
    {
        joueur.animator.Play(joueur.animName);
        yield return new WaitForSeconds(0.2f);
    
        joueur.shot.enabled = true;
        joueur.aud.Play();
        takeDmg();
        yield return new WaitForSeconds(0.25f);
        joueur.shot.enabled = false;
    }
    public void takeDmg()
    {
        
        hp = hp - joueur.dmg;
        Debug.Log(hp);
        if (hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<EnemyBase>().enabled = false;
        GetComponent<NpcBase>().enabled = false;
        GetComponent<InteractableEnemy>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        animator.Play("Dying");
        questManager.CompleteQuest(1);
    }
  
}

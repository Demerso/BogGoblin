﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class InteractableNpc : Clickable
{
    AddSound dvl;
    bool soundPlaying = false;
    public Canvas canvas;
    public UnityEvent onInteract = new UnityEvent();

    private QuestGiver questGiver;

    private bool isQuestGiver;
    private void Start()
    {
        base.Start();
        questGiver = GetComponent<QuestGiver>();
        isQuestGiver = questGiver != null;
    }

    public override void DeFocus()
    {
        base.DeFocus();
        if (isQuestGiver)
        {
            if (questGiver.HasFocus())
            {
                questGiver.LoseFocus();
            }
        }
    }


    public override void interact()
    {
        onInteract.Invoke();
        questGiver.GiveQuest();
        dvl = GetComponent<AddSound>();
        //maybe add slow turn, for now instant
        transform.rotation = Quaternion.LookRotation(-player.forward); // look at player,temporary maybe because isnt facing npc, npc will look away
        if(soundPlaying == false)
        {
            StartCoroutine(Sound());
        }
        
   

        
       
    }


    private IEnumerator Sound()
    {
        soundPlaying = true;
        dvl.voiceLine.clip = dvl.vl[Random.Range(0,dvl.vl.Length-1)];
        dvl.voiceLine.Play();
        yield return new WaitForSeconds(dvl.voiceLine.clip.length +0.5f);
        soundPlaying = false;
        
    }



   

}

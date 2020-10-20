using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InteractableNpc : Clickable
{
    AddSound dvl;
    bool soundPlaying = false;
    public Canvas canvas;
    private QuestMenu qm;
    public Quest quest;
    private void Start()
    {
        base.Start();
        qm = canvas.GetComponent<QuestMenu>();
        
    }

    public override void DeFocus()
    {
        base.DeFocus();
        if (qm.active)
        {
            Debug.Log(qm.active);
            qm.CloseQuest();
        }
        
    }


    public override void interact()
    {

        qm.ShowQuest(this);
        dvl = GetComponent<AddSound>();
        //maybe add slow turn, for now instant
        transform.rotation = Quaternion.LookRotation(-player.forward); // look at player,temporary maybe because isnt facing npc, npc will look away
        
        
        if(soundPlaying == false)
        {
            StartCoroutine(Sound());
        }
        
   

        
       
    }
    /*
    private IEnumerator Turn()
    {
        while(transform.forward != -player.forward)
        {
            transform.Rotate(Vector3.up * Time.deltaTime*10);
            yield return null; 
        }
    }*/

    private IEnumerator Sound()
    {
        soundPlaying = true;
        dvl.voiceLine.clip = dvl.vl[Random.Range(0,dvl.vl.Length-1)];
        dvl.voiceLine.Play();
        yield return new WaitForSeconds(dvl.voiceLine.clip.length +0.5f);
        soundPlaying = false;
        
    }



   

}

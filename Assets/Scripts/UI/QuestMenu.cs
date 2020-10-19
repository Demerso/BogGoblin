using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMenu : MonoBehaviour
{
    // Start is called before the first frame update

    
    public GameObject questUI;
    public AudioSource AS;
    public AudioClip[] AC;
    private WaitForSeconds wait = new WaitForSeconds(0.5f);
    public bool active = false;
    // Update is called once per frame
    private void Start()
    {
        AS = this.GetComponent<AudioSource>();
        questUI.SetActive(false);
       
    }
    public void ShowQuest()
    {
        active = true;
        questUI.SetActive(true);
        StartCoroutine(Sound(AC[0]));
    }
    public void CloseQuest()
    {
        active = false;
        questUI.SetActive(false);
        StartCoroutine(Sound(AC[1]));
    }

    private IEnumerator Sound(AudioClip x)
    {
        yield return wait;
        AS.clip = x;
        AS.Play();
        
    }

}

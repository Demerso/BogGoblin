using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestMenu : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject questUI;
    [SerializeField] private Text questDescription;
    [SerializeField] private QuestManager questManager;
    [SerializeField] private GameObject buttons;
    public AudioSource AS;
    public AudioClip[] AC;
    private WaitForSeconds wait = new WaitForSeconds(0.5f);

    private QuestGiver currGiver;

    public bool active = false;
    // Update is called once per frame
    private void Start()
    {
        AS = this.GetComponent<AudioSource>();
        questUI.SetActive(false);
       
    }
    public void ShowQuest(QuestGiver giver)
    {
        currGiver = giver;
        questDescription.text = giver.GetQuest().description;
        questUI.SetActive(true);
        active = true;
        StartCoroutine(Sound(AC[0]));
    }

    public void ShowNoQuest()
    {
        questDescription.text = "I have no quest for you";
        buttons.SetActive(false);
        questUI.SetActive(true);
        active = true;
        StartCoroutine(Sound(AC[0]));
    }
    
    public void CloseQuest()
    {
        buttons.SetActive(true);
        questUI.SetActive(false);
        active = false;
        StartCoroutine(Sound(AC[1]));
        currGiver = null;
    }

    public void AcceptQuest()
    {
        questManager.AddQuest(currGiver);
        CloseQuest();
    }

    private IEnumerator Sound(AudioClip x)
    {
        yield return wait;
        AS.clip = x;
        AS.Play();
        
    }

}

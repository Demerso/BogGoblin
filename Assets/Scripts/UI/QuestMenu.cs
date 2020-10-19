using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestMenu : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject questUI;
    [SerializeField] private Text questDescription;
    [SerializeField] private GameObject buttons;
    [SerializeField] private QuestManager manager;
    public AudioSource AS;
    public AudioClip[] AC;
    private WaitForSeconds wait = new WaitForSeconds(0.5f);

    private InteractableNpc currNpc;

    public bool active = false;
    // Update is called once per frame
    private void Start()
    {
        AS = this.GetComponent<AudioSource>();
        questUI.SetActive(false);
       
    }
    public void ShowQuest(InteractableNpc npc)
    {
        currNpc = npc;
        questDescription.text = currNpc.quest.description;
        buttons.SetActive(currNpc.quest.canAccept);
        questUI.SetActive(true);
        active = true;
        StartCoroutine(Sound(AC[0]));
    }
    public void CloseQuest()
    {
        questUI.SetActive(false);
        active = false;
        StartCoroutine(Sound(AC[1]));
        currNpc = null;
    }

    public void AcceptQuest()
    {
        manager.AddQuest(currNpc.quest);
        currNpc.quest = Quest.NoQuest();
        CloseQuest();
    }

    private IEnumerator Sound(AudioClip x)
    {
        yield return wait;
        AS.clip = x;
        AS.Play();
        
    }

}

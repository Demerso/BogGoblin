using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
public struct Quest
{
    public int id;
    public bool canAccept;
    public bool completed;
    public string name;
    public string description;

    public static Quest NoQuest()
    {
        var q = new Quest()
        {
            canAccept = false,
            name = "No quest",
            description = "I have no quest for you."
        };
        return q;
    }
}

public class QuestManager : MonoBehaviour
{

    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private GameObject questPrefab;
    
    private Hashtable quests;

    private void Start()
    {
        quests = new Hashtable();
        gameObject.SetActive(false);
    }

    public void AddQuest(Quest quest)
    {
        quests.Add(quest.id, quest);
        GetQuestShown(quest);
    }

    public void CompleteQuest(int id)
    {
        var quest = (Quest) quests[id];
        quest.completed = true;
        scrollRect.content.transform.GetChild(id).GetComponent<Toggle>().isOn = true;
    }
    
    public void OpenDisplay()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    private void GetQuestShown(Quest quest)
    {
        var q = Instantiate(questPrefab, scrollRect.content.transform);
        q.GetComponentInChildren<Text>().text = quest.name;
    }
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    private List<Quest> quests;

    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private GameObject questDisplayPrefab;
    [SerializeField] public QuestMenu questMenu;

    private void Start()
    {
        quests = new List<Quest>();
        gameObject.SetActive(false);
    }

    public void ToggleDisplay()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    private void UpdateQuests()
    {
        ClearDisplay();
        foreach (var quest in quests)
        {
            var q = Instantiate(questDisplayPrefab, scrollRect.content.transform);
            q.GetComponent<Toggle>().isOn = quest.isComplete;
            q.GetComponentInChildren<Text>().text = quest.name;
        }
    }
    
    public void AddQuest(QuestGiver giver)
    {
        var quest = giver.ConsumeQuest();
        switch (quest.questType)
        {
            case QuestType.Kill:
                quest.killEnemy.health.onDeath.AddListener(quest.CompleteQuest);
                break;
            case QuestType.Interact:
                quest.interactNpc.onInteract.AddListener(quest.CompleteQuest);
                break;
        }
        quest.onUpdate.AddListener(UpdateQuests);
        quests.Add(quest);
        UpdateQuests();
    }

    public void ProposeQuest(QuestGiver giver)
    {
        questMenu.ShowQuest(giver);
    }
    
    private void ClearDisplay()
    {
        foreach (RectTransform child in scrollRect.content.transform)
            Destroy(child.gameObject);
    }

}

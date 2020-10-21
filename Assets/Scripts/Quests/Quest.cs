using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Quest
{
    public bool isComplete;
    public bool bypassAccept;
    public QuestGiver questGiver;

    public string name;
    public string description;

    public QuestType questType;
    
    public InteractableEnemy killEnemy;
    public InteractableNpc interactNpc;

    [System.NonSerialized] public UnityEvent onUpdate = new UnityEvent();

    public void CompleteQuest()
    {
        isComplete = true;
        questGiver.GiveQuest();
        onUpdate.Invoke();
    }

}


public enum QuestType
{
    Kill, Interact
}
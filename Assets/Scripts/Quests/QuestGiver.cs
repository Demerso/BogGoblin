using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Quest[] quests;
    
    [SerializeField] private QuestManager questManager;
    
    private int currQuest = 0;


    private void Start()
    {
        if (quests[0].bypassAccept)
        {
            GiveQuest();
        }
    }
    
    public void GiveQuest()
    {
        if (currQuest >= quests.Length) return;
        if (quests[currQuest].bypassAccept)
        {
            questManager.AddQuest(this);
        }
        else
        {
            questManager.ProposeQuest(this);
        }
            
    }

    public Quest ConsumeQuest()
    {
        return quests[currQuest++];
    }

    public Quest GetQuest()
    {
        return quests[currQuest];
    }

    public void LoseFocus()
    {
        questManager.questMenu.CloseQuest();
    }

    public bool HasFocus()
    {
        return questManager.questMenu.gameObject.activeSelf;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestHolder : Singleton<QuestHolder>
{
    [SerializeField] GameObject player;
    [SerializeField] private TextMeshProUGUI questSummaryTitle;
    [SerializeField] private TextMeshProUGUI questSummaryProgress;
    [SerializeField] public GameObject doneIcon;

    public Quest quest;

    public void Jump(){
        quest = null;
        QuestManger.Instance.updateQuest();
    }

    public void EnemyKilled(KillTarget other){
        quest.goal.EnemyKilled(other);
        updateQuestUI();
        if(quest.goal.isReached()){
            // reward

            quest = null;
            QuestManger.Instance.updateQuest();
        }
    }

    public void ItemGathered(GatherObjectType other){
        quest.goal.ItemGathered(other);
        updateQuestUI();
        if(quest.goal.isReached()){
            // reward

            quest = null;
            QuestManger.Instance.updateQuest();
        }
    }

    public void updateQuestUI()
    {
        questSummaryTitle.text = quest.title;
        questSummaryProgress.text = quest.goal.currentAmount + "/" + quest.goal.requiredAmount;

        if(quest.goal.isReached())
        {
            doneIcon.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHolder : Singleton<QuestHolder>
{
    [SerializeField] GameObject player;

    public Quest quest;

    public void Jump(){
        quest = null;
        QuestManger.Instance.updateQuest();
    }

    public void EnemyKilled(KillTarget other){
        quest.goal.EnemyKilled(other);
        if(quest.goal.isReached()){
            // reward

            quest = null;
            QuestManger.Instance.updateQuest();
        }
    }

    public void ItemGathered(GatherObjectType other){
        quest.goal.ItemGathered(other);
        if(quest.goal.isReached()){
            // reward

            quest = null;
            QuestManger.Instance.updateQuest();
        }
    }
}

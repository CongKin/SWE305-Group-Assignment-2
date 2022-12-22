using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestHolder : Singleton<QuestHolder>
{
    [SerializeField] GameObject player;
    [SerializeField] private TextMeshProUGUI questSummaryTitle;
    [SerializeField] private TextMeshProUGUI questSummaryProgress;
    [SerializeField] public GameObject doneIcon;
    [SerializeField] public GameObject button; 

    public Quest quest;

    public void Jump(){
        quest = null;
        QuestManger.Instance.updateQuest();
    }

    public void EnemyKilled(KillTarget other){
        quest.goal.EnemyKilled(other);
        updateQuestUI();
        if(quest.goal.isReached()){
            QuestManger.Instance.updateQuest();
        }
    }

    public void ItemGathered(GatherObjectType other){
        quest.goal.ItemGathered(other);
        updateQuestUI();
        if(quest.goal.isReached()){
            QuestManger.Instance.updateQuest();
        }
    }

    public void updateQuestUI()
    {
        questSummaryTitle.text = quest.title;
        questSummaryProgress.text = quest.goal.currentAmount + "/" + quest.goal.requiredAmount;
        Debug.Log("update Quest UI");

        if(quest.goal.isReached())
        {
            button.GetComponent<Button>().enabled = true;
            doneIcon.SetActive(true);
        }
    }

    public void collectReward()
    {
        CoinManager.Instance.AddCoins(quest.coinReward);
        player.GetComponent<CharacterStats>().increaseEXP((float)quest.expReward);
        quest = null;
        button.SetActive(false);
    }
}

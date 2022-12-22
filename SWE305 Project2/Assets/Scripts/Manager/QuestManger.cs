using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestManger : Singleton<QuestManger>
{
    [SerializeField] private GameObject questWindow;

    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI expText;

    [SerializeField] public List<QuestNPC> questList;

    private int currentQuest = 0;
    QuestNPC questNPC= new QuestNPC();

    void Awake(){
        assignQuest();
    }

    public void updateQuest(){
        currentQuest++;
        assignQuest(); 
    }

    private void assignQuest(){
        if(questList[currentQuest] != null){
            
            questNPC = questList[currentQuest];

            questNPC.npc.GetComponent<QuestGiver>().spriteRenderer.enabled = true;
            questNPC.npc.GetComponent<QuestGiver>().quest = questNPC.quest;
        }
    }

    public void openQuestWindow(Quest quest){
        Debug.Log("Open quest window");
        questWindow.SetActive(true);
        title.text = quest.title;
        description.text = quest.description;
        coinText.text = quest.coinReward.ToString()+" coins";
        expText.text = quest.expReward.ToString()+" exp";
    }

    public void acceptQuest(){
        questWindow.SetActive(false);
        questNPC.npc.GetComponent<QuestGiver>().quest.isActive = true;
        questNPC.npc.GetComponent<QuestGiver>().spriteRenderer.enabled = false;
        QuestHolder.Instance.quest = questNPC.npc.GetComponent<QuestGiver>().quest;
        QuestHolder.Instance.updateQuestUI();
        QuestHolder.Instance.doneIcon.SetActive(false);
        QuestHolder.Instance.button.SetActive(true);
        QuestHolder.Instance.button.GetComponent<Button>().enabled = false;
        questNPC.npc.GetComponent<QuestGiver>().quest = null;
    }
}

[System.Serializable]
public class QuestNPC{
    public Quest quest;
    public GameObject npc;
}

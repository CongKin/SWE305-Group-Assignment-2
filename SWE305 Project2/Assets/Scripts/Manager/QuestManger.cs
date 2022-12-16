using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManger : Singleton<QuestManger>
{
    [SerializeField] private GameObject questWindow;

    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI appleText;
    [SerializeField] private TextMeshProUGUI expText;

    [SerializeField] public List<QuestNPC> questList;

    private int currentQuest = 0;
    private readonly int taskParamater = Animator.StringToHash("task");

    private void Start(){
        assignQuest();
    }

    public void updateQuest(){
        assignQuest(); 
    }

    private void assignQuest(){
        if(questList[currentQuest] != null){
            QuestNPC questNPC= new QuestNPC();
            questNPC = questList[currentQuest];

            questNPC.quest.isActive = true;
            questNPC.npc.GetComponent<QuestGiver>().animator.SetBool(taskParamater, true);
            questNPC.npc.GetComponent<QuestGiver>().quest = questNPC.quest;
        }
    }

    public void openQuestWindow(Quest quest){
        Debug.Log("Open quest window");
        questWindow.SetActive(true);
        title.text = quest.title;
        description.text = quest.description;
        appleText.text = quest.appleReward.ToString()+" apples";
        expText.text = quest.expReward.ToString()+" exp";

    }

    public void closeQuestWindow(){
        questWindow.SetActive(false);
    }
}

[System.Serializable]
public class QuestNPC{
    public Quest quest;
    public GameObject npc;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManger : MonoBehaviour
{
    [SerializeField] public List<QuestNPC> questList;

    private int currentQuest = 0;

    private void Start(){
        QuestNPC questNPC= new QuestNPC();
        questNPC = questList[currentQuest];

        questNPC.npc.GetComponent<QuestGiver>().quest = questNPC.quest;
        
    }

    public void updateQuest(){
        currentQuest++;
        if(questList[currentQuest] != null){
            QuestNPC questNPC= new QuestNPC();
            questNPC = questList[currentQuest];

            questNPC.npc.GetComponent<QuestGiver>().quest = questNPC.quest;
        }
    }
}

[System.Serializable]
public class QuestNPC{
    public Quest quest;
    public GameObject npc;
}

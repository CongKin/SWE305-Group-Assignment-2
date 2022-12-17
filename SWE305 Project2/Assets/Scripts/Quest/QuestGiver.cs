using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] public Quest quest;
    [SerializeField] public Character character;

    [SerializeField] public Animator animator;

    private readonly int taskParamater = Animator.StringToHash("task");
    private readonly int taskProgressParameter = Animator.StringToHash("taskprogress");
    private readonly int taskDoneParamater = Animator.StringToHash("taskdone");
    private readonly int taskAcceptParamater = Animator.StringToHash("taskaccept");

    private void OnTriggerEnter2D(Collider2D other){
        if(quest.isActive == true){
            if(other.CompareTag("Player")){
                Debug.Log("Detect Player");
                QuestManger.Instance.openQuestWindow(quest);
                Debug.Log("Done detect");
            }
        }
    }

    public void acceptQuest(){
        QuestManger.Instance.closeQuestWindow();
        quest.isActive = true;
        animator.SetBool(taskProgressParameter, true);
    }
}

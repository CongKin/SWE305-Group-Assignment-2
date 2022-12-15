using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] public Quest quest;
    [SerializeField] public Character character;

    [SerializeField] private GameObject questWindow;

    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI appleText;
    [SerializeField] private TextMeshProUGUI expText;

    [SerializeField]private Animator animator;

    private void OnTriggerEnter2D(Collider2D other){
        if(quest.isAvailable == true){
            if(quest.isActive == false){
                if(other.CompareTag("Player")){
                    openQuestWindow();
                }
            }
        }
    }

    private void openQuestWindow(){
        questWindow.SetActive(true);
        title.text = quest.title;
        description.text = quest.description;
        appleText.text = quest.appleReward.ToString()+" apples";
        expText.text = quest.expReward.ToString()+" exp";

    }

    public void acceptQuest(){
        questWindow.SetActive(false);
        quest.isActive = true;
    }
}

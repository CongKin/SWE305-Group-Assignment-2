using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest = new Quest();
    [SerializeField] public Character character;

    [SerializeField] public SpriteRenderer spriteRenderer;

    private void OnTriggerEnter2D(Collider2D other){
        if(quest.title != ""){
            if(quest.isActive == false){
                if(other.CompareTag("Player")){
                    QuestManger.Instance.openQuestWindow(quest);
                }
            }
        }
        
    }

    
}

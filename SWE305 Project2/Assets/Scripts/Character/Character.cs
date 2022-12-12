 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum CharacterTypes
    {
        Player,
        AI
    }
    
    [SerializeField] private CharacterTypes characterType;
    [SerializeField] private GameObject characterSprite;
    [SerializeField] private Animator characterAnimator;
    [SerializeField] private UI_Inventory uiInventory;

    private Inventory inventory;

    private void Awake(){
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if (itemWorld != null){
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }
    
    public CharacterTypes CharacterType => characterType;
    public GameObject CharacterSprite => characterSprite;
    public Animator CharacterAnimator => characterAnimator;
} 
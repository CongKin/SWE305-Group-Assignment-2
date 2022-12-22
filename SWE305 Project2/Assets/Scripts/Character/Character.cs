using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static Character Instance { get; private set; }

    public enum CharacterTypes
    {
        Player,
        AI,
        NPC
    }
    
    [SerializeField] private CharacterTypes characterType;
    [SerializeField] private GameObject characterSprite;
    [SerializeField] private Animator characterAnimator;
    [SerializeField] private UI_Inventory uiInventory;

    private Inventory inventory;

    private void Awake(){
        Instance = this;

        inventory = new Inventory(UseItem);
        //uiInventory.SetPlayer(this);
        uiInventory.SetInventory(inventory);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if (itemWorld != null){
                if(inventory.isFull<8){
                    inventory.isFull++;
                    inventory.AddItem(itemWorld.GetItem());
                    itemWorld.DestroySelf();
                }
                else
                    Debug.Log("Full");
        }
    }

    private void UseItem(Item item) {
        switch (item.itemType) {
        case Item.ItemType.smallPotion:
            
            inventory.RemoveItem(new Item { itemType = Item.ItemType.smallPotion, amount = 1 });
            inventory.isFull--;
            break;
        
        case Item.ItemType.mediumPotion:
            
            inventory.RemoveItem(new Item { itemType = Item.ItemType.mediumPotion, amount = 1 });
            inventory.isFull--;
            break;
        
        case Item.ItemType.bigPotion:
            
            inventory.RemoveItem(new Item { itemType = Item.ItemType.bigPotion, amount = 1 });
            inventory.isFull--;
            break;
        }
    }

    public Vector3 GetPosition() {
        return transform.position;
    }

    public CharacterTypes CharacterType => characterType;
    public GameObject CharacterSprite => characterSprite;
    public Animator CharacterAnimator => characterAnimator;

    // public bool AnimationComplete()
    // {
    //     if (characterAnimator.GetCurrentAnimatorStateInfo(0).length > characterAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime)
    //     {
    //         return true;
    //     }

    //     return false;
    // }
} 
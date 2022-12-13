using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static Character Instance { get; private set; }

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
        Instance = this;    

        inventory = new Inventory(UseItem);
        uiInventory.SetPlayer(this);
        uiInventory.SetInventory(inventory);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if (itemWorld != null){
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }

    private void UseItem(Item item) {
        switch (item.itemType) {
        case Item.ItemType.Health:
            
            inventory.RemoveItem(new Item { itemType = Item.ItemType.Health, amount = 1 });
            break;
        case Item.ItemType.Mana:
            
            inventory.RemoveItem(new Item { itemType = Item.ItemType.Mana, amount = 1 });
            break;
        }
    }

    public Vector3 GetPosition() {
        return transform.position;
    }

    public CharacterTypes CharacterType => characterType;
    public GameObject CharacterSprite => characterSprite;
    public Animator CharacterAnimator => characterAnimator;
} 
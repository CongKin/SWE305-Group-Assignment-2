using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    public static Character Instance { get; private set; }
    [SerializeField] private UI_Inventory uiInventory;
    [SerializeField] private Character character;

    private Inventory inventory;

    private void Awake(){
        Instance = character;

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
            
            character.GetComponent<Health>().GainHealth(5);
            inventory.RemoveItem(new Item { itemType = Item.ItemType.smallPotion, amount = 1 });
            inventory.isFull--;
            break;
        
        case Item.ItemType.mediumPotion:
            
            character.GetComponent<Health>().GainHealth(10);
            inventory.RemoveItem(new Item { itemType = Item.ItemType.mediumPotion, amount = 1 });
            inventory.isFull--;
            break;
        
        case Item.ItemType.bigPotion:
            
            character.GetComponent<Health>().GainHealth(15);
            inventory.RemoveItem(new Item { itemType = Item.ItemType.bigPotion, amount = 1 });
            inventory.isFull--;
            break;
        }
    }

    public Vector3 GetPosition() {
        return transform.position;
    }
}

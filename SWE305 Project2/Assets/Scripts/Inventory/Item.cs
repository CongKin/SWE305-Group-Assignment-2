using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item {

    public enum ItemType {
        smallPotion,
        mediumPotion,
        bigPotion
    }

    public ItemType itemType;
    public int amount;
    public int isFull;


    public Sprite GetSprite() {
        switch (itemType) {
        default:
        case ItemType.smallPotion:       return ItemAssets.Instance.smallPotion;
        case ItemType.mediumPotion:       return ItemAssets.Instance.mediumPotion;
        case ItemType.bigPotion:       return ItemAssets.Instance.bigPotion;
        }
    }

    public bool IsStackable() {
        switch (itemType) {
        default:
        case ItemType.smallPotion:
        case ItemType.mediumPotion:
        case ItemType.bigPotion:
            return true;
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item {

    public enum ItemType {
        Health,
        ClothSack,
        Pumpkin
    }

    public ItemType itemType;
    public int amount;
    public int isFull;


    public Sprite GetSprite() {
        switch (itemType) {
        default:
        case ItemType.Health:       return ItemAssets.Instance.healthSprite;
        case ItemType.ClothSack:       return ItemAssets.Instance.clothSackSprite;
        case ItemType.Pumpkin:       return ItemAssets.Instance.pumpkinSprite;
        }
    }

    public bool IsStackable() {
        switch (itemType) {
        default:
        case ItemType.Health:
        case ItemType.ClothSack:
        case ItemType.Pumpkin:
            return true;
        }
    }

}

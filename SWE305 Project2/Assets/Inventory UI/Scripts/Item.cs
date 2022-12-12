using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item {

    public enum ItemType {
        Sword,
        Health,
        Mana,
        Coin,
        Medkit,
    }

    public ItemType itemType;
    public int amount;


    public Sprite GetSprite() {
        switch (itemType) {
        default:
        case ItemType.Sword:        return ItemAssets.Instance.swordSprite;
        case ItemType.Health:       return ItemAssets.Instance.healthSprite;
        case ItemType.Mana:         return ItemAssets.Instance.manaSprite;
        case ItemType.Coin:         return ItemAssets.Instance.coinSprite;
        case ItemType.Medkit:       return ItemAssets.Instance.medkitSprite;
        }
    }

    public Color GetColor() {
        switch (itemType) {
        default:
        case ItemType.Sword:        return new Color(1, 1, 1);
        case ItemType.Health:       return new Color(1, 0, 0);
        case ItemType.Mana:         return new Color(0, 0, 1);
        case ItemType.Coin:         return new Color(1, 1, 0);
        case ItemType.Medkit:       return new Color(1, 0, 1);
        }
    }

    public bool IsStackable() {
        switch (itemType) {
        default:
        case ItemType.Coin:
        case ItemType.Health:
        case ItemType.Mana:
            return true;
        case ItemType.Sword:
        case ItemType.Medkit:
            return false;
        }
    }

}

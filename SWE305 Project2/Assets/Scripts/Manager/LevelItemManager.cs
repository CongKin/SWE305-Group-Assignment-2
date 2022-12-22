using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelItemManager : MonoBehaviour
{
    [SerializeField] public List<EnemyPosition> enemyList;
    [SerializeField] public List<ItemPosition> itemList;

    public void spawnEnemy()
    {
        for(int i=0; i<enemyList.Count; i++)
        {
            Instantiate(enemyList[i].enemy, enemyList[i].position);
        }
    }

    public void spawnItem()
    {
        for(int i=0; i<itemList.Count; i++)
        {
            Instantiate(itemList[i].item, itemList[i].position);
        }
    }

    public void destroyEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        for(int i=0; i<enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }
    }

    public void destroyItem()
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");

        for(int i=0; i<items.Length; i++)
        {
            Destroy(items[i]);
        }
    }
}

[System.Serializable]
public class EnemyPosition{
    public GameObject enemy;
    public Transform position;
}

[System.Serializable]
public class ItemPosition{
    public GameObject item;
    public Transform position;
}
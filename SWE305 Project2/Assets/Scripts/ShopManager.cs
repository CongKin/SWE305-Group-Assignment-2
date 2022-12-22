using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int[,] shopItems = new int[5,5];
    public float currency;
    public Text CurrencyTXT;
    public Sprite smallPotion;
    public Sprite mediumPotion;
    public Sprite bigPotion;

    private Inventory inventory;



    // Start is called before the first frame update
    void Start()
    {
        CurrencyTXT.text = "$: " + currency.ToString();

        //ID
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;


        //Prices = equals the value
        shopItems[2, 1] = 10;
        shopItems[2, 2] = 20;

        //Quantity, 0 cause havent buy anything
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
 


    }

    public void Purchase()
    {   
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if(currency >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            currency -=shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            CurrencyTXT.text = "$: " + currency.ToString();
            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();

            ItemWorld itemWorld = GetComponent<ItemWorld>();
            inventory.isFull++;
            inventory.AddItem(itemWorld.GetItem());
        }
    }
}

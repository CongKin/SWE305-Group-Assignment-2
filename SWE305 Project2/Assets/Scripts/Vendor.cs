using System;
using System.Collections;
using System.Collections.Generic;
//using System.Reflection;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
public class Vendor : MonoBehaviour
{
 [Header("Panels")]
[SerializeField] private GameObject popUpPanel;
[SerializeField] private GameObject shopPanel;
 [Header("Items")]
 [SerializeField] private VendorItem bigPotion;
 [SerializeField] private VendorItem mediumPotion;
 [SerializeField] private VendorItem smallPotion;
private bool canOpenShop;
 private CharacterWeapon characterWeapon;

 private void Update()
 {
 if (canOpenShop)
 {
 if (Input.GetKeyDown(KeyCode.O))
 {
 shopPanel.SetActive(true);
 popUpPanel.SetActive(false);
 }
 }
 if (shopPanel.activeInHierarchy)
 {
 BuyItems();
 }
 }

 private void BuyItems()
 {
	if (Input.GetKeyDown(KeyCode.Z))
	{
		if (CoinManager.Instance.Coins >= bigPotion.Cost)
		{
			smallPotion.smallPotion.AddHealth(characterWeapon.GetComponent<Character>());
			ProductBought(smallPotion.Cost);
		}
	}

	if (Input.GetKeyDown(KeyCode.X))
	{
		if (CoinManager.Instance.Coins >= mediumPotion.Cost)
		{
			mediumPotion.mediumPotion.AddHealth(characterWeapon.GetComponent<Character>());
			ProductBought(mediumPotion.Cost);
		}
	}

	if (Input.GetKeyDown(KeyCode.C))
	{
		if (CoinManager.Instance.Coins >= smallPotion.Cost)
		{
			bigPotion.bigPotion.AddHealth(characterWeapon.GetComponent<Character>());
			ProductBought(bigPotion.Cost);
		}
	}
 }

 private void OnTriggerEnter2D(Collider2D other)
 {
 if (other.CompareTag("Player"))
 {
 characterWeapon = other.GetComponent<CharacterWeapon>();
 canOpenShop = true;
 popUpPanel.SetActive(true);
 }
}
 private void OnTriggerExit2D(Collider2D other)
 {
 if (other.CompareTag("Player"))
 {
 characterWeapon = null;
 canOpenShop = false;
 popUpPanel.SetActive(false);
 shopPanel.SetActive(false);
 }
}
 private void ProductBought(int amount)
 {
 shopPanel.SetActive(false);
 CoinManager.Instance.RemoveCoins(amount);
 }
}

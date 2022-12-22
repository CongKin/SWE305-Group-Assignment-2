using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;	

public class UIManager : Singleton<UIManager>
{
    [Header("Settings")]
    [SerializeField] private Image healthBar;
    [SerializeField] private Image experienceBar;
    [SerializeField] private TextMeshProUGUI currentHealthTMP;
    [SerializeField] private TextMeshProUGUI currentExperienceTMP;
    [SerializeField] private TextMeshProUGUI currentLevelTMP;

    [Header("Weapon")]
	private TextMeshProUGUI currentAmmoTMP;
    private Image weaponImage;

    [Header("Text")] 
    [SerializeField] private TextMeshProUGUI coinsTMP;

    private float playerCurrentHealth;
    private float playerMaxHealth;
    private float playerMaxExperience;
    private float playerCurrentExperience;
    private int playerCurrentLevel;
    private bool isPlayer;

    private int playerCurrentAmmo;
    private int playerMaxAmmo;

    private void Update()
    {
        InternalUpdate();
    }
    
    public void UpdateHealth(float currentHealth, float maxHealth, bool isThisMyPlayer)
    { 
        playerCurrentHealth = currentHealth;
        playerMaxHealth = maxHealth;
        isPlayer = isThisMyPlayer;       
	}

    public void UpdateExperience (float currentExperience, float maxExperience, bool isThisMyPlayer)
    {
        playerCurrentExperience = currentExperience;
        playerMaxExperience = maxExperience;
        isPlayer = isThisMyPlayer;
    }

    public void UpdateLevel(int currentLevel, bool isThisMyPlayer)
    {
        playerCurrentLevel = currentLevel;
        isPlayer = isThisMyPlayer;
    }

    public void UpdateWeaponSprite(Sprite weaponSprite)
    { 
        weaponImage.sprite = weaponSprite;
        weaponImage.SetNativeSize();
    }

    public void UpdateAmmo(int currentAmmo, int maxAmmo)
    {
        playerCurrentAmmo = currentAmmo;
        playerMaxAmmo = maxAmmo;
    }

    private void InternalUpdate()
    {
        if (isPlayer)
        {     
           healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, playerCurrentHealth / playerMaxHealth, 10f * Time.deltaTime);
           currentHealthTMP.text = playerCurrentHealth.ToString() + "/" + playerMaxHealth.ToString(); 

           experienceBar.fillAmount = Mathf.Lerp(experienceBar.fillAmount, playerCurrentExperience / playerMaxExperience, 10f * Time.deltaTime);
           currentExperienceTMP.text = playerCurrentExperience.ToString() + "/" + playerMaxExperience.ToString();

           currentLevelTMP.text = playerCurrentLevel.ToString();
        }
 

        // Update Coins
        coinsTMP.text = CoinManager.Instance.Coins.ToString();   
    }
}

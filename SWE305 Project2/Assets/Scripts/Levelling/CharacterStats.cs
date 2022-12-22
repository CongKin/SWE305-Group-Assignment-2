using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int level = 1;

    private float currHealth;
    private float maxH;
    [SerializeField]public float currExp;
    [SerializeField]private float maxExp;

    public float baseDamage;

    [SerializeField]private float expRatio;
    [SerializeField]private float healthRatio;
    [SerializeField]private float dmgRatio;
    private Health health;

    void Start()
    {
        health = GetComponent<Health>();

        level = 1;
        currHealth = health.CurrentHealth;
        maxH = health.maxHealth;
        currExp = 0;
        maxExp = 100;
        baseDamage = 10;
        expRatio = 1.4f;
        healthRatio = 1.3f;
        dmgRatio= 1.3f;
        maxExp = 100;

        UIManager.Instance.UpdateLevel(level, true);
        PlayerDamageManager.Instance.UpdateBaseDamage((int) baseDamage);
    }

    void Update()
    {
        UIManager.Instance.UpdateExperience((float)currExp, (float)maxExp, true);
        
        if(currExp >= maxExp)
        {
            currExp -= maxExp;
            LevelUp();
        }
    }

    public void UpdateUI()
    {
        UIManager.Instance.UpdateHealth(health.CurrentHealth, health.maxHealth, true);
        UIManager.Instance.UpdateExperience((float)currExp, (float)maxExp, true);
        UIManager.Instance.UpdateLevel(level, true);
    }

    private void LevelUp()
    {
        currHealth = health.CurrentHealth;

        level ++;
        currHealth *= healthRatio;
        maxH *= healthRatio;

        health.CurrentHealth = (float) Math.Ceiling(currHealth);
        health.maxHealth = (float) Math.Ceiling(maxH);


        currExp *= expRatio;
        maxExp *= expRatio;

        currExp = (float) Math.Ceiling(currExp);
        maxExp = (float) Math.Ceiling(maxExp);
        
        baseDamage *= dmgRatio; 
        PlayerDamageManager.Instance.UpdateBaseDamage((int) baseDamage);
        
        // levelUpIcon.gameObject.SetActive(true);SS

        UpdateUI();
    }

    public void increaseEXP(float exp)
    {
        currExp += exp;
    }
}

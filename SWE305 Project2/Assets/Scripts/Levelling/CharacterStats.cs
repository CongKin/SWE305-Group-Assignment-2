using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : Health
{
    public int level = 1;

    public float currHealth;
    public float maxH;
    public float currExp;
    public float maxExp;

    public float baseDamage;

    [SerializeField]private float expRatio;
    [SerializeField]private float healthRatio;
    [SerializeField]private float dmgRatio;

    void Start()
    {
        level = 1;
        expRatio = 1.4f;
        healthRatio = 1.3f;
        dmgRatio= 1.55f;
        maxExp = 100;
    }

    void Update()
    {
        UIManager.Instance.UpdateExperience((float)currExp, (float)maxExp, true);

        if(currExp >= maxExp)
        {
            LevelUp();
        }
    }

    public void UpdateUI()
    {
        UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth, true);
        UIManager.Instance.UpdateExperience((float)currExp, (float)maxExp, true);
        UIManager.Instance.UpdateLevel(level, true);
    }

    private void LevelUp()
    {
        level ++;
        currHealth *= healthRatio;
        maxH *= healthRatio;

        CurrentHealth = (float) Math.Ceiling(currHealth);
        maxHealth = (float) Math.Ceiling(maxH);
        
        currExp *= expRatio;
        maxExp *= expRatio;

        currExp = (float) Math.Ceiling(currExp);
        maxExp = (float) Math.Ceiling(maxExp);
        
        baseDamage *= dmgRatio; 
        PlayerDamageManager.Instance.UpdateBaseDamage((int) baseDamage);
        
        // levelUpIcon.gameObject.SetActive(true);
        currExp = 0;

        UpdateUI();
    }
}

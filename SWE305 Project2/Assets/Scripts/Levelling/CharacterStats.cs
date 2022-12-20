using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int level;

    public int currHealth;
    public int maxHealth;

    public int currMana;
    public int maxMana;

    public int currExp;
    public int maxExp;

    public int strength;
    public int intelligence;
    public int endurance;
    public int agility;
    public int speed;

    void Start()
    {

    }

    void Update()
    {
        UpdateUI();

        if(currExp >= maxExp)
        {
            level+=1;
            // currrentStatPoints += 5;
            // levelUpIcon.gameObject.SetActive(true);
            currExp = 0;
        }
    }

    public void UpdateUI()
    {
        // healthBar.value = currHealth;
        // manaBar.value = currMana;
        // expBar.value = currExp;

        // healthBar.maxValue = maxHealth;
        // manaBar.maxValue = maxMana;
        // expBar.maxValue = maxExp;

    }
}

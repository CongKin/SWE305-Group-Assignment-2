using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageManager : Singleton<PlayerDamageManager>
{
    [SerializeField] private GameObject player;
    private int baseDamage;

    public void UpdateBaseDamage(int baseDmg)
    {
        baseDamage = baseDmg;
    }

    public int getBaseDamage()
    {
        return baseDamage;
    }
}

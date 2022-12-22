using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{    
    [SerializeField] private int damageToApplyArrow = 1;
    [SerializeField] private int damageToApplyDragon= 1;
    [SerializeField] private int damageToApplyBoss = 1;
    
    private Health playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<Health>();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet_arrow") && other.gameObject.layer != 13) //13 is PlayerProjectile layer
        {
            Debug.Log("damage to apply" + damageToApplyArrow);
            playerHealth.TakeDamage(damageToApplyArrow);
        }
        else if (other.CompareTag("Bullet_dragon") && other.gameObject.layer != 13) //13 is PlayerProjectile layer
        {
            Debug.Log("damage to apply" + damageToApplyDragon);
            playerHealth.TakeDamage(damageToApplyDragon);
        }
        else if (other.CompareTag("Bullet_boss") && other.gameObject.layer != 13) //13 is PlayerProjectile layer
        {
            Debug.Log("damage to apply" + damageToApplyBoss);
            playerHealth.TakeDamage(damageToApplyBoss);
        }
    }
}
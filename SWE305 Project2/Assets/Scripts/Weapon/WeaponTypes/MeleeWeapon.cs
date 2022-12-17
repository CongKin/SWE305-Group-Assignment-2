using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] private float attackDelay = 1.5f;

    private Collider2D damageAreaCollider2D;
    private Animator animator;
    private bool attacking;

    //private readonly int useMeeleWeapon = Animator.StringToHash("UseMeleeWeapon");
    
    private void Start()
    {
        damageAreaCollider2D = GetComponentInChildren<Collider2D>();
        //animator = GetComponentInChildren<Animator>();
    }
    
    public override void UseWeapon()
    {
        //Debug.Log("use melee weapon");
        StartCoroutine(Attack());
    }

    protected override void Update()
    {
        base.Update();
        FlipMeeleWeapon();
    }

    private IEnumerator Attack()
    {
        if (attacking)
        {
            yield break;
        }

        Debug.Log("Attacking");
        //Attack
        attacking = true;
        damageAreaCollider2D.enabled = true;
        //animator.SetTrigger(useMeeleWeapon);

        // Stop Attack
        yield return new WaitForSeconds(attackDelay);
        damageAreaCollider2D.enabled = false;
        attacking = false;
        if(damageAreaCollider2D.enabled == false)
        {
            Debug.Log("deactivate collider");
        }
    }

    private void FlipMeeleWeapon()
    {
        if (WeaponOwner.GetComponent<CharacterFlip>().FacingRight)
        {
            transform.GetChild(0).localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.GetChild(0).localScale = new Vector3(-1, 1, 1);
        }
    }
}

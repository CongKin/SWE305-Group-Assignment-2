using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Health : MonoBehaviour
{    
    [Header("Health")]
    [SerializeField] protected float initialHealth = 10f;
    [SerializeField] protected float maxHealth = 10f;

    [Header("Settings")] 
    [SerializeField] private bool destroyObject;

    private Character character;
    private CharacterController controller;
    private Collider2D collider2D;
	private SpriteRenderer spriteRenderer;
	private EnemyHealth enemyHealth;
    private Transform transform;

    private bool isPlayer;
    private bool canDestroy = false;

    [SerializeField]private GameObject expPrefab;
    [SerializeField]private float expCount = 1.0f;

    // Controls the current health of the object    
    public float CurrentHealth { get; set; }

    public KillTarget killTarget;
    private Vector3 expRandPosition;

    private void Awake()
    {
        character = GetComponent<Character>();
        controller = GetComponent<CharacterController>();
        collider2D = GetComponent<Collider2D>();      
        enemyHealth = GetComponent<EnemyHealth>();  
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        transform = GetComponentInChildren<Transform>();

        CurrentHealth = initialHealth;

        if (character != null)
        {
            isPlayer = character.CharacterType == Character.CharacterTypes.Player;
            // if(isPlayer)
            //     Debug.Log("is player");
            // if(!isPlayer)
            //     Debug.Log("not player");
        }
         
        UpdateCharacterHealth();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(1);
        }
    }

    // Take the amount of damage we pass in parameters
    public void TakeDamage(int damage)
    {
        Debug.Log("Character Take Damage");
        Debug.Log("damage" + damage);
        Debug.Log(CurrentHealth);
        if (CurrentHealth <= 0)
        {
            return;
        }
        
        CurrentHealth -= damage;

        UpdateCharacterHealth();

        if (CurrentHealth <= 0)
        {
            Debug.Log("Die");
            Die();
        }
    }

    // Kills the game object
    private void Die()
    {
        if (character != null)
        {
            if(!isPlayer)
            {
                //Debug.Log("inside");
                for (int i = 0; i < expCount; i ++)
                {
                    //Debug.Log("exp");
                    GameObject exp = Instantiate(expPrefab);
                    expRandPosition.x = Random.Range(-1,1);
                    expRandPosition.y = 0;
                    exp.transform.localPosition = transform.position + expRandPosition;
                    exp.transform.rotation = transform.rotation;
                }

                QuestHolder.Instance.EnemyKilled(killTarget);
                canDestroy = true;
            }
            else{
                //Debug.Log("Outside");
                canDestroy = true;
            }

            if(canDestroy == true)
            {
                //Debug.Log("not AI");
                collider2D.enabled = false;
                spriteRenderer.enabled = false;

                character.enabled = false;
                controller.enabled = false;
            }
        
        }

        if (destroyObject)
        {
            //Debug.Log("destroy obj");
            DestroyObject();
        }
    }
    
    // Revive this game object    
    public void Revive()
    {
        if (character != null)
        {
            collider2D.enabled = true;
            spriteRenderer.enabled = true;

            character.enabled = true;
            controller.enabled = true;
        }

        gameObject.SetActive(true);

        CurrentHealth = initialHealth;

        UpdateCharacterHealth();
    }

    public void GainHealth(int amount)
    {
        CurrentHealth = Mathf.Min(CurrentHealth + amount, maxHealth);
        UpdateCharacterHealth();
    }
	
	
    // If destroyObject is selected, we destroy this game object
    private void DestroyObject()
    {
        gameObject.SetActive(false);
    }

    private void UpdateCharacterHealth()
	{
        // Update Enemy health
        if (enemyHealth != null)
        {
            //Debug.Log("update enemy");
            enemyHealth.UpdateEnemyHealth(CurrentHealth, maxHealth);
        }  
      
        // Update Player health
        if (character != null && isPlayer)
        {
            //Debug.Log("update player: " + isPlayer);
            UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth, isPlayer);
        }
    }   

}
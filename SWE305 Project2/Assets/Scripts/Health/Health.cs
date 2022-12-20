using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{    
    [Header("Health")]
    [SerializeField] private float initialHealth = 10f;
    [SerializeField] private float maxHealth = 10f;

    [Header("Shield")] 
    [SerializeField] private float initialShield = 5f;
    [SerializeField] private float maxShield = 5f;

    [Header("Settings")] 
    [SerializeField] private bool destroyObject;

    private Character character;
    private CharacterController controller;
    private Collider2D collider2D;
	private SpriteRenderer spriteRenderer;
	private EnemyHealth enemyHealth;
    private Transform transform;

    private bool isPlayer;
    private bool shieldBroken;
    private bool canDestroy = false;

    [SerializeField]private GameObject expPrefab;
    [SerializeField]private float expCount = 1.0f;

    // Controls the current health of the object    
    public float CurrentHealth { get; set; }

    // Returns the current health of this character
    public float CurrentShield { get; set; }
    
    private void Awake()
    {
        character = GetComponent<Character>();
        controller = GetComponent<CharacterController>();
        collider2D = GetComponent<Collider2D>();      
        enemyHealth = GetComponent<EnemyHealth>();  
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        transform = GetComponentInChildren<Transform>();

        CurrentHealth = initialHealth;
        CurrentShield = initialShield;

        if (character != null)
        {
            isPlayer = character.CharacterType == Character.CharacterTypes.Player;
            if(isPlayer)
                Debug.Log("is player");
            if(!isPlayer)
                Debug.Log("not player");
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
        if (CurrentHealth <= 0)
        {
            return;
        }

        if (!shieldBroken && character != null)
        {
            CurrentShield -= damage;

            UpdateCharacterHealth();

            if (CurrentShield <= 0)
            {
                shieldBroken = true;
            }
            return;
        }
        
        CurrentHealth -= damage;

        UpdateCharacterHealth();

        if (CurrentHealth <= 0)
        {
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
                Debug.Log("inside");
                for (int i = 0; i < expCount; i ++)
                {
                    Debug.Log("exp");
                    GameObject exp = Instantiate(expPrefab);
                    exp.transform.localPosition = transform.position;
                    exp.transform.rotation = transform.rotation;
                }
                canDestroy = true;
            }
            else{
                Debug.Log("Outside");
                canDestroy = true;
            }

            if(canDestroy == true)
            {
                Debug.Log("not AI");
                collider2D.enabled = false;
                spriteRenderer.enabled = false;

                character.enabled = false;
                controller.enabled = false;
            }
        
        }

        if (destroyObject)
        {
            Debug.Log("destroy obj");
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
        CurrentShield = initialShield;

        shieldBroken = false;
       
        UpdateCharacterHealth();
    }

    public void GainHealth(int amount)
    {
        CurrentHealth = Mathf.Min(CurrentHealth + amount, maxHealth);
        UpdateCharacterHealth();
    }
	
    public void GainShield(int amount)
    {
        CurrentShield = Mathf.Min(CurrentShield + amount, maxShield);
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
            enemyHealth.UpdateEnemyHealth(CurrentHealth, maxHealth);
        }  
      
        // Update Player health
        if (character != null)
        {
            UIManager.Instance.UpdateHealth(CurrentHealth, maxHealth, isPlayer);
        }
    }   
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour
{
    // public UnityEvent shootingEvent;
    [SerializeField] private float speed = 100f;
    [SerializeField] private float acceleration = 0f;

    // CharacterWeapon characterWeapon;
    // protected readonly int shootingParamater = Animator.StringToHash("Shooting");

    // Returns the direction of this projectile    
    public Vector2 Direction { get; set; }
    
    // Returns if the projectile is facing right   
    public bool FacingRight { get; set; }

    // Returns the speed of the projectile    
    public float  Speed { get; set; }

    public Character ProjectileOwner { get; set; }
    
    // Internal
    private Rigidbody2D myRigidbody2D;
    private Collider2D collider2D;
    [SerializeField]private SpriteRenderer spriteRenderer;
	private Vector2 movement; 
	private bool canMove;
    [SerializeField]private Animator animator;
    
    private void Awake()
    {
        Speed = speed;
        FacingRight = true;
        canMove = true;
		                
        myRigidbody2D = GetComponent<Rigidbody2D>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
        //animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {       
        if (canMove)
        {
            MoveProjectile();
        }
    }
    
    // Moves this projectile  
    public void MoveProjectile()
    {
        movement = Direction * (Speed / 10f ) * Time.fixedDeltaTime;
        myRigidbody2D.MovePosition(myRigidbody2D.position + movement);

        Speed += acceleration * Time.deltaTime;
    }
   
    // Flips this projectile   
    public void FlipProjectile()
    {   
        if (spriteRenderer != null)
        {
           // Debug.Log("flip");
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }
  
    // Set the direction and rotation in order to move  
    public void SetDirection(Vector2 newDirection, Quaternion rotation, bool isFacingRight = true)
    {
        Direction = newDirection;
        //Debug.Log("set diretion");
        
        if (FacingRight != isFacingRight)
        {
            //Debug.Log("Facing not right");
            FlipProjectile();
        }

        
        transform.rotation = rotation;
        
    }

    public void ResetProjectile()
    {
        spriteRenderer.flipX = false;
	}

    public void DisableProjectile()
    {
        canMove = false;
        spriteRenderer.enabled = false;
        collider2D.enabled = false;
    }

    public void EnableProjectile()
    {
        // shootingEvent.Invoke();
        // characterWeapon.animator.SetTrigger(shootingParameter);
        canMove = true;
        spriteRenderer.enabled = true;
        collider2D.enabled = true;
    }
}
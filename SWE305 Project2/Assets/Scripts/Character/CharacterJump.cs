using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : CharacterComponents
{
    [SerializeField] private float jumpSpeed = 10f;
    [SerializeField] private float doubleJumpSpeed = 5f;

    private Rigidbody2D myRigidbody;
    private BoxCollider2D myFeet;
    private bool canDoubleJump;

    private readonly int jumpParamater = Animator.StringToHash("Jump");
    private readonly int fallParamater = Animator.StringToHash("Fall");
    private readonly int idleParamater = Animator.StringToHash("Idle");
    private readonly int doubleJumpParamater = Animator.StringToHash("DoubleJump");
    private readonly int doubleJumpFallParameter = Animator.StringToHash("DoubleFall");

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myFeet = GetComponent<BoxCollider2D>();
    }

    protected override void HandleAbility()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        UpdateAnimations();
    }

    private bool CheckGrounded()
    {
        bool isGround;
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
        Debug.Log("Character is ground: " + isGround);
        return isGround;
    }

    private void Jump()
    {
        if(CheckGrounded())
        {
            character.CharacterAnimator.SetBool(jumpParamater, true);
            Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
            myRigidbody.velocity = Vector2.up * jumpVel;
            canDoubleJump = true;
        }
        else
        {
            if(canDoubleJump)
            {
                character.CharacterAnimator.SetBool(doubleJumpParamater, true);
                Vector2 doubleJumpVel = new Vector2(0.0f, doubleJumpSpeed);
                myRigidbody.velocity = Vector2.up * doubleJumpVel;
                canDoubleJump = false;
            }
        }
    }

    private void UpdateAnimations()
    {
        
        if (character.CharacterAnimator.GetBool("Jump"))
        {
            if(myRigidbody.velocity.y < 0.0f)
            {
                character.CharacterAnimator.SetBool(jumpParamater, false);
                character.CharacterAnimator.SetBool(fallParamater, true);
            }

        }
        else if(CheckGrounded())
        {
            character.CharacterAnimator.SetBool(fallParamater, false);
            character.CharacterAnimator.SetBool(idleParamater, true);
        }

        if (character.CharacterAnimator.GetBool(doubleJumpParamater))
        {
            if (myRigidbody.velocity.y < 0.0f)
            {
                character.CharacterAnimator.SetBool(doubleJumpParamater, false);
                character.CharacterAnimator.SetBool(doubleJumpFallParameter, true);
            }

        }
        else if (CheckGrounded())
        {
            character.CharacterAnimator.SetBool(doubleJumpParamater, false);
            character.CharacterAnimator.SetBool(idleParamater, true);
        }
    }

}

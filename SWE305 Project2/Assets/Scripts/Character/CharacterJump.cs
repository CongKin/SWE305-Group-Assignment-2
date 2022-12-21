using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : CharacterComponents
{
    [SerializeField] private int jumpPower;
    private float jumpDuration = 0.1f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private bool isGround;
    private bool isJumping;
    private bool canDoubleJump;
    private float jumpTimer;

    protected override void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    protected override void HandleAbility()
    {
        base.HandleAbility();

        SwitchAnimation();

        if (isJumping)
        {
            if(jumpTimer < jumpDuration)
            {
                jumpTimer += Time.deltaTime;
            }else
            {
                CheckGrounded();
                if (isGround)
                {
                    StopJump();
                }
            }   
        }
    }

    void CheckGrounded()
    {
        isGround = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.0f, 0.2f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        //controller.myCapsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    private void Jump()
    {
        CheckGrounded();

        if(isGround)
        {
            isJumping = true;
            jumpTimer = 0f;
            animator.SetBool("Jump", true);
            controller.myRigidbody2D.velocity = new Vector2(controller.myRigidbody2D.velocity.x, jumpPower);
            canDoubleJump = true;
            //Debug.Log("Jump");
        }
        else
        {
            if(canDoubleJump)
            {
                animator.SetBool("DoubleJump", true);
                jumpTimer = 0f;
                controller.myRigidbody2D.velocity = new Vector2(controller.myRigidbody2D.velocity.x, jumpPower);
                canDoubleJump = false;
            }
        }
    }

    private void StopJump()
    {
        isJumping = false;
        controller.NormalMovement = true;
    }

    private void SwitchAnimation()
    {
        animator.SetBool("Idle", false);
        if (animator.GetBool("Jump"))
        {
            if(controller.myRigidbody2D.velocity.y < 0.0f)
            {
                animator.SetBool("Jump", false);
                animator.SetBool("Fall", true);
            }

        }
        else if(isGround)
        {
            animator.SetBool("Fall", false);
            animator.SetBool("Idle", true);
        }

        if (animator.GetBool("DoubleJump"))
        {
            if (controller.myRigidbody2D.velocity.y < 0.0f)
            {
                animator.SetBool("DoubleJump", false);
                animator.SetBool("DoubleFall", true);
            }

        }
        else if (isGround)
        {
            animator.SetBool("DoubleFall", false);
            animator.SetBool("Idle", true);
        }


    }
}

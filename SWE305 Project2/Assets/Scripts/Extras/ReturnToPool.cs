using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPool : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private LayerMask objectMask;
	[SerializeField] private float lifeTime = 2f;
    [SerializeField]private Animator animator;

    // [Header("Effects")]
    // [SerializeField] private ParticleSystem impactPS;

    private float delayTime;
    private Projectile projectile;    

    private void Start()
    {
        projectile = GetComponent<Projectile>();
        delayTime = 1.0f;
    }

    // Returns this object to the pool
    private void Return()
    {
        if (projectile != null)
        {
            projectile.ResetProjectile();
        }  
      
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CheckLayer(other.gameObject.layer, objectMask))
        {

            if (projectile != null)
            {
                if(animator != null)
                {
                    animator.SetTrigger("explode");
                    StartCoroutine(Delay(delayTime));
                }
                else{
                    projectile.DisableProjectile();
                }
                
            }
            // impactPS.Play();
            // Invoke(nameof(Return), impactPS.main.duration);
        }
    }

    private bool CheckLayer(int layer, LayerMask objectMask)
    {
        return ((1 << layer) & objectMask) != 0;
    }
    
    private void OnEnable()
    {
        Invoke(nameof(Return), lifeTime);       
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    IEnumerator Delay (float delayTime)
    {
        yield return new WaitForSeconds (delayTime);
        projectile.DisableProjectile();
    }
}
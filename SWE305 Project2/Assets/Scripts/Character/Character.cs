using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static Character Instance { get; private set; }

    public enum CharacterTypes
    {
        Player,
        AI,
        NPC
    }
    
    [SerializeField] private CharacterTypes characterType;
    [SerializeField] private GameObject characterSprite;
    [SerializeField] private Animator characterAnimator;

    public CharacterTypes CharacterType => characterType;
    public GameObject CharacterSprite => characterSprite;
    public Animator CharacterAnimator => characterAnimator;

    // public bool AnimationComplete()
    // {
    //     if (characterAnimator.GetCurrentAnimatorStateInfo(0).length > characterAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime)
    //     {
    //         return true;
    //     }

    //     return false;
    // }
} 
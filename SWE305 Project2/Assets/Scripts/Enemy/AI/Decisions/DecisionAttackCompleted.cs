using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/Attack Completed", fileName = "DecisionAttackCompleted")]
public class DecisionAttackCompleted : AIDecision
{
    public override bool Decide(StateController controller)
    {
        return AttackCompleted(controller);
    }

    private bool AttackCompleted(StateController controller)
    {
        Debug.Log("decision attack completed");
        if(controller.CharacterWeapon.CurrentWeapon.GetComponentInChildren<Animator>() == null)
        {
            if(controller.CharacterWeapon.AttackAnimationComplete())
            {
                Debug.Log("attack completed");
                return true;
            }   
        }

        else{
            if (controller.CharacterWeapon.CurrentWeapon.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length
            > controller.CharacterWeapon.CurrentWeapon.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime)
            {
                return true;
            }
        }
        //Debug.Log("attack not complete");
        return false;
    }
}
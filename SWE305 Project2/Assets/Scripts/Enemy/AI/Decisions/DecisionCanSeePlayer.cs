using System.Collections;
using System.Collections.Generic;
//using System.Xml.Serialization;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/Can See Player", fileName = "DecisionCanSeePlayer")]
public class DecisionCanSeePlayer : AIDecision
{
    public LayerMask obstacleMask;
    
    public float viewDistance;

    public override bool Decide(StateController controller)
    {
        EvaluateWeaponDirection(controller);
        return CanSeePlayer(controller);
    }

    private bool CanSeePlayer(StateController controller)
    {
        // float distanceToPlayer = (controller.Player.position - controller.transform.position).sqrMagnitude;
        float distanceToPlayer = Vector2.Distance(controller.transform.position, controller.Player.transform.position);
    
        if(distanceToPlayer < viewDistance)
        {
            Debug.Log("Can See Player");
            controller.Target = controller.Player;
            return true;
        }

        Debug.Log("Cannot See Playe");
        controller.Target = null;
        return false;
    }

    private void EvaluateWeaponDirection(StateController controller)
    {
        if (controller.Target == null)
        {
            if (controller.CharacterWeapon.CurrentWeapon.WeaponOwner.GetComponent<CharacterFlip>().FacingRight)
            {
                controller.CharacterWeapon.CurrentWeapon.WeaponAim.SetAim(Vector2.right);
            }
            else
            {
                controller.CharacterWeapon.CurrentWeapon.WeaponAim.SetAim(Vector2.left);
            }
        }
    }
} 
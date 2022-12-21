using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;
    public KillTarget killTarget;
    public GatherObjectType gatherObjectType;

    public int requiredAmount;
    public int currentAmount;

    public bool isReached(){
        return (currentAmount >= requiredAmount);
    }

    public void EnemyKilled(KillTarget other){
        if(goalType == GoalType.Kill){
            if(other == killTarget){
                currentAmount++;
            }
        }
    }

    public void ItemGathered(GatherObjectType other){
        if(goalType == GoalType.Gather){
            if(other == gatherObjectType){
                currentAmount++;
            }
        }
    }
}

public enum GoalType{
    Kill,
    Gather
}

public enum KillTarget{
    dragon,
    archer,
    swear,
    mud,
    boss
}

public enum GatherObjectType{
    apple,
    wood
}

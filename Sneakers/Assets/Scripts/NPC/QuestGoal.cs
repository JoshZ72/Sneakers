using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;
    public Target target;

    public int requiredAmount;
    public int currentAmount;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void EnemyKilled()
    {
        if (goalType == GoalType.Kill)
        {
            currentAmount++;
        }

    }

    public void ItemCollected()
    {
        if (goalType == GoalType.Collect)
        {
            currentAmount++;
        }

    }

    public void ItemReturned()
    {
        if (goalType == GoalType.Return)
        {
            currentAmount++;
        }

    }

}

public enum Target
{
    Cyborgs,
    Humans,
    Any

}

public enum GoalType
{
    Kill,
    Collect,
    Return
}
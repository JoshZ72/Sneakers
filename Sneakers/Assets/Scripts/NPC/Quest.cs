using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool isActive;

    public string title;
    public string description;

    public QuestGoal goal;

    public int HappinessReward;

    public void Complete()
    {
        isActive = false;
        Debug.Log(title + " was completed!");
    }
}

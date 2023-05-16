using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HappyLevels
{
    public int CyborgHappiness;
    public int HumanHappiness;

    public void AddCyborgHappiness(int amount)
    {
        CyborgHappiness += amount;
    }

    public void AddHumanHappiness(int amount)
    {
        HumanHappiness += amount;
    }

    public void RemoveCyborgHappiness(int amount)
    {
        CyborgHappiness -= amount;
    }

    public void RemoveHumanHappiness(int amount)
    {
        HumanHappiness -= amount;
    }

    public int GetCyborgHappiness()
    {
        return CyborgHappiness;
    }

    public int GetHumanHappiness()
    {
        return HumanHappiness;
    }
}

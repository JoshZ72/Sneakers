using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HappyLevels
{
    public int Happiness = 50;

    public void AddCyborgHappiness(int amount)
    {
        Happiness -= amount;
    }

    public void AddHumanHappiness(int amount)
    {
        Happiness += amount;
    }

    public int GetHappiness()
    {
        return Happiness;
    }
}

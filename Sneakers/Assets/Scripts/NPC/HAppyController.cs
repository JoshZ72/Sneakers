using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappyController : MonoBehaviour
{
    public HappyLevels happyLevels;
    public Slider happyBar;
    private bool cyborgIsMad;
    private bool humanIsMad;

    // Start is called before the first frame update
    void Start()
    {
        cyborgIsMad = false;
        humanIsMad = false;
    }

    // Update is called once per frame
    void Update()
    {
        happyBar.value = happyLevels.GetHappiness();
    }

    public void AddCyborgHappiness(int amount)
    {
        happyLevels.AddCyborgHappiness(amount);
    }

    public void AddHumanHappiness(int amount)
    {
        happyLevels.AddHumanHappiness(amount);
    }

    public int GetHappiness()
    {
        return happyLevels.GetHappiness();
    }

    public void changeCyborgIsMad(bool newBool)
    {
        cyborgIsMad = newBool;
    }
    
    public void changeHumanIsMad(bool newBool)
    {
        humanIsMad = newBool;
    }

    public bool GetCyborgIsMad()
    {
        return cyborgIsMad;
    }

    public bool GetHumanIsMad()
    {
        return humanIsMad;
    }
}

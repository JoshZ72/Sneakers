using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideExit : MonoBehaviour
{

    private bool canExit;
    // Start is called before the first frame update
    void Start()
    {
        canExit = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "Vehicle")
        {
            canExit = false;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        canExit = true;
    }

    public bool ReturnCanExit()
    {
        return canExit;
    }
}

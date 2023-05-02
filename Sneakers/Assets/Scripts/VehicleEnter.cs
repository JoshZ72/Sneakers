using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleEnter : MonoBehaviour
{
    public GameObject vehicle;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.SetActive(false);
                vehicle.GetComponent<TestVehicle>().enabled = true;
            }
            Debug.Log("inrange");
        }
    }
}

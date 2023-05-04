using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleEnter : MonoBehaviour
{
    public GameObject vehicle;
    public GameObject player;
    private bool inVehicle;
    private float coolDown;
    // Start is called before the first frame update
    void Start()
    {
        inVehicle = false;
        coolDown = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (inVehicle && (Time.time > coolDown))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.transform.position = transform.position;
                vehicle.GetComponent<TestVehicle>().enabled = false;
                player.SetActive(true);
                inVehicle = false;
                coolDown = Time.time + 1f;
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            if (!inVehicle && (Time.time > coolDown))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    player.SetActive(false);
                    vehicle.GetComponent<TestVehicle>().enabled = true;
                    inVehicle = true;
                    coolDown = Time.time + 1f;
                }
            }
        }
    }
}

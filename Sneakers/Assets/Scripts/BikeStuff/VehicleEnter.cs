using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleEnter : MonoBehaviour
{
    public GameObject vehicle;
    public GameObject player;
    private bool inVehicle;
    private float coolDown;
    private GameObject leftExit;
    private GameObject rightExit;
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
                leftExit = vehicle.transform.GetChild(2).gameObject;
                rightExit = vehicle.transform.GetChild(3).gameObject;
                if (leftExit.GetComponent<SideExit>().ReturnCanExit())
                {
                    player.transform.position = leftExit.transform.position;
                    vehicle.GetComponent<VehicleInput>().enabled = false;
                    player.SetActive(true);
                    inVehicle = false;
                    coolDown = Time.time + .5f;
                }
                else if (rightExit.GetComponent<SideExit>().ReturnCanExit())
                {
                    player.transform.position = rightExit.transform.position;
                    vehicle.GetComponent<VehicleInput>().enabled = false;
                    player.SetActive(true);
                    inVehicle = false;
                    coolDown = Time.time + .5f;
                }
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
                    vehicle.GetComponent<VehicleInput>().enabled = true;
                    inVehicle = true;
                    coolDown = Time.time + .5f;
                }
            }
        }
    }
}

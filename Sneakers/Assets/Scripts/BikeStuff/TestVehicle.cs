using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVehicle : MonoBehaviour
{
    public float verticalInputAcceleration = 1;
    public float horizontalInputAcceleration = 20;

    public float maxSpeed = 10;
    public float maxRotationSpeed = 100;

    public float velocityDrag = 1;
    public float rotationDrag = 1;

    private Vector3 velocity;
    private float zRotationVelocity;
    private float inputVertical;
    private float inputHorizontal;

    public GameObject playerOnBike;

    private void Start()
    {
        
        playerOnBike.SetActive(false);
    }


    private void Update()
    {
        if (GetComponent<VehicleInput>().enabled == true)
        {
            inputVertical = GetComponent<VehicleInput>().ReturnVInput();
            inputHorizontal = GetComponent<VehicleInput>().ReturnHInput();
        }
        else
        {
            inputVertical = 0;
            inputHorizontal = 0;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            playerOnBike.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            playerOnBike.SetActive(false);
        }

        //Debug.Log("Vert: " + inputVertical);
        //Debug.Log("Horiz: " + inputHorizontal);
        // apply forward input
        Vector3 acceleration = inputVertical * verticalInputAcceleration * transform.up;
        velocity += acceleration * Time.deltaTime;

        // apply turn input
        float zTurnAcceleration = -1 * inputHorizontal * horizontalInputAcceleration;
        zRotationVelocity += zTurnAcceleration * Time.deltaTime;
        //Debug.Log("Vert" + Input.GetAxis("Vertical"));
        //Debug.Log("Horiz" + Input.GetAxis("Horizontal"));
        //Debug.Log("Accel" + acceleration);
        //Debug.Log("turn" + zTurnAcceleration);
        //Debug.Log("Vel" + velocity);
        //Debug.Log("turnVel" + zRotationVelocity);
    }

    private void FixedUpdate()
    {
        // apply velocity drag
        velocity = velocity * (1 - Time.deltaTime * velocityDrag);

        // clamp to maxSpeed
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        // apply rotation drag
        zRotationVelocity = zRotationVelocity * (1 - Time.deltaTime * rotationDrag);

        // clamp to maxRotationSpeed
        zRotationVelocity = Mathf.Clamp(zRotationVelocity, -maxRotationSpeed, maxRotationSpeed);

        // update transform
        transform.position += velocity * Time.deltaTime;
        transform.Rotate(0, 0, zRotationVelocity * Time.deltaTime);
    }
}
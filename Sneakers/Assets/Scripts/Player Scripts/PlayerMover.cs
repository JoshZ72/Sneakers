using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    //public int playerspeed = 5;
    public int rotationSpeed = 10;

    

    public float verticalInputAcceleration = 1;
    public float horizontalInputAcceleration = 20;

    public float maxSpeed;
    public float sprintSpeed;
    private float speed;
    //public float maxRotationSpeed = 100;

    public float velocityDrag = 1;
    public float rotationDrag = 1;

    private Vector3 velocityV;
    private Vector3 velocityH;
    private Vector3 velocity;
    //private float zRotationVelocity;
    private Vector3 accelerationV;
    private Vector3 accelerationH;
    private bool toggleSprint = false;

    void Start()
    {
        speed = maxSpeed;
    }

    private void Update()
    {
        Camera.main.transform.position = new Vector3(transform.position.x,
            transform.position.y,
            transform.position.z - 10);

       

        // apply forward input

        accelerationV = Input.GetAxis("Vertical") * verticalInputAcceleration * Vector3.up;

        // apply turn input
        accelerationH = Input.GetAxis("Horizontal") * horizontalInputAcceleration * Vector3.right;

        velocityH += accelerationH * Time.deltaTime;
        velocityV += accelerationV * Time.deltaTime;
        

        //float zTurnAcceleration = -1 * Input.GetAxis("Horizontal") * horizontalInputAcceleration;
        //zRotationVelocity += zTurnAcceleration * Time.deltaTime;
        /*
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction to look at the mouse cursor
        Vector3 direction = mousePos - transform.position;
        direction.z = 0f;

        // Rotate the object to face the mouse cursor
        transform.up += direction.normalized * rotationSpeed * Time.deltaTime;
        */
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (toggleSprint)
            {
                toggleSprint = false;
                speed = maxSpeed;
            }
            else
            {
                toggleSprint = true;
                speed = sprintSpeed;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0 && toggleSprint)
        {
            toggleSprint = false;
            speed = maxSpeed;
        }
        // apply velocity drag
        velocityV = velocityV * (1 - Time.deltaTime * velocityDrag);
        velocityH = velocityH * (1 - Time.deltaTime * velocityDrag);

        // clamp to maxSpeed
        velocityV = Vector3.ClampMagnitude(velocityV, speed);
        velocityH = Vector3.ClampMagnitude(velocityH, speed);

        // apply rotation drag
        //zRotationVelocity = zRotationVelocity * (1 - Time.deltaTime * rotationDrag);

        // clamp to maxRotationSpeed
        //zRotationVelocity = Mathf.Clamp(zRotationVelocity, -maxRotationSpeed, maxRotationSpeed);
        velocity = velocityV + velocityH;
        if ((velocity.y > 1f || velocity.y < -1f) && (velocity.y < 1f || velocity.y > -1f))
        {
            velocity = (velocityV + velocityH) / 1.2f;
        }
        // update transform
        transform.position += velocity * Time.deltaTime;
        //transform.Rotate(0, 0, zRotationVelocity * Time.deltaTime);
    }


}

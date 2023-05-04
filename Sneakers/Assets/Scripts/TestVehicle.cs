using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVehicle : MonoBehaviour
{
    //public int playerspeed = 5;
    public int rotationSpeed = 10;



    public float verticalInputAcceleration = 1;
    public float horizontalInputAcceleration = 20;

    public float maxSpeed;
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
    private float angle;

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
    }

    private void FixedUpdate()
    {
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
            velocity = (velocityV + velocityH) / 1.3f;
        }

        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);


        /*
        if ((velocity.x > -3 && velocity.x < 3) && (velocity.y > -3 && velocity.y < 3))
        {

        }
        else if (velocity.y > 1  && (velocity.x < 1 && velocity.x > -1))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (velocity.y < 1 && (velocity.x < 1 && velocity.x > -1))
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (velocity.x < 1 && (velocity.y < 1 && velocity.y > -1))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (velocity.x > 1 && (velocity.y < 1 && velocity.y > -1))
        {
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
        else if (velocity.x > 1 && velocity.y > 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 315);
        }
        else if (velocity.x < 1 && velocity.y < 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 135);
        }
        else if (velocity.x > 1 && velocity.y < 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 225);
        }
        else if (velocity.x < 1 && velocity.y > 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
        }
        */

        //Debug.Log(velocity);
        // update transform
        transform.position += velocity * Time.deltaTime;
        //transform.Rotate(0, 0, zRotationVelocity * Time.deltaTime);
    }


}
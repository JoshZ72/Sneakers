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
    public float maxRotationSpeed = 100;

    public float velocityDrag = 1;
    public float rotationDrag = 1;

    private Vector3 velocity;
    private float zRotationVelocity;
    private Vector3 acceleration;
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

        acceleration = Input.GetAxis("Vertical") * verticalInputAcceleration * transform.up;

        // apply turn input


        float zTurnAcceleration = -1 * Input.GetAxis("Horizontal") * horizontalInputAcceleration;
        zRotationVelocity += zTurnAcceleration * Time.deltaTime;
        
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction to look at the mouse cursor
        Vector3 direction = mousePos - transform.position;
        direction.z = 0f;

        // Rotate the object to face the mouse cursor
        transform.up += direction.normalized * rotationSpeed * Time.deltaTime;
        
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
        
        if ((velocity.y > 1f || velocity.y < -1f) && (velocity.y < 1f || velocity.y > -1f))
        {
            velocity = velocity / 1.3f;
        }

        // update transform
        transform.position += velocity * Time.deltaTime;
        transform.Rotate(0, 0, zRotationVelocity * Time.deltaTime);
    }


}
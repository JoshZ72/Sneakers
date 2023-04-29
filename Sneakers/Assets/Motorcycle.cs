using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motorcycle : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Move the bike based on input axes
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.AddForce(movement * speed);

        // Handle bike drifting left/right based on input axes
        float driftForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.left)) * 2.0f;
        Vector2 relativeForce = Vector2.right * driftForce;

        rb.AddForce(rb.GetRelativeVector(relativeForce));
        rb.rotation -= moveHorizontal * turnSpeed * rb.velocity.magnitude * 0.1f;

        //Apply the drift force to the bike
        rb.AddForce(transform.right * driftForce, ForceMode2D.Force);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 mousePosition;
    private GameObject playerObject;

    //Bike stuff
    private bool isOnBike = false;
    private Motorcycle bike;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerObject = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {
        Camera.main.transform.position = new Vector3(transform.position.x,
            transform.position.y,
            transform.position.z - 10);


        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePosition - rb.position;
        transform.right = direction;




        if (isOnBike)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            //Move the bike based on input axes
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb.AddForce(movement * bike.speed);

            //Handle bike drifting left/right based on input axes
        }
        else
        {
            //Make sure the bike is stationary when the player is not using it
            rb.velocity = Vector2.zero;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isOnBike)
            {
                //Player hops off the bike
                isOnBike = false;
                playerObject.transform.parent = null; //detach player from bike
            }
            else if (bike != null)
            {
                //Player hops onto the bike
                isOnBike = true;
                playerObject.transform.parent = bike.transform; //attach player to bike
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void OnTriggerStay2D(Collider2D other)
    {

        Debug.Log("You're on");
        if (Input.GetKeyDown(KeyCode.E) && !isOnBike)
        {
            if (other.CompareTag("Motorcycle"))
            {
                bike = other.GetComponent<Motorcycle>();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("You're off");
        if (other.CompareTag("Motorcycle"))
        {
            bike = null;
        }
    }
}

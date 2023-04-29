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
   

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        

    }

    
}

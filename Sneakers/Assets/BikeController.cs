using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour
{
    public float bikeSpeed = 5f;
    public float bikeRotateSpeed = 200f;
    public float bikeDriftSpeed = 1f;
    public KeyCode mountKey = KeyCode.E;
    public KeyCode dismountKey = KeyCode.E;

    private bool isMounted = false;
    private Rigidbody2D bikeRigidbody;
    private Transform playerTransform;

    void Start()
    {
        bikeRigidbody = GetComponent<Rigidbody2D>();
        playerTransform = transform.Find("Player");

        if (playerTransform == null)
        {
            Debug.LogError("Player transform not found");
        }
    }

    void Update()
    {
        if (!isMounted && Input.GetKeyDown(mountKey))
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Player"))
                {
                    playerTransform.SetParent(transform);
                    playerTransform.localPosition = Vector3.zero;
                    isMounted = true;
                    break;
                }
            }
        }
        else if (isMounted && Input.GetKeyDown(dismountKey))
        {
            playerTransform.SetParent(null);
            isMounted = false;
        }
    }

    void FixedUpdate()
    {
        if (isMounted)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            float driftInput = Mathf.Lerp(0f, Input.GetAxis("Horizontal"), Mathf.Abs(Input.GetAxis("Vertical")));

            float rotation = horizontalInput * bikeRotateSpeed * Time.fixedDeltaTime;
            transform.Rotate(0f, 0f, -rotation);

            Vector2 movement = transform.up * bikeSpeed * verticalInput * Time.fixedDeltaTime;
            bikeRigidbody.MovePosition(bikeRigidbody.position + movement);

            Vector2 driftForce = -transform.right * driftInput * bikeDriftSpeed * Time.fixedDeltaTime;
            bikeRigidbody.AddForce(driftForce, ForceMode2D.Impulse);
        }
    }
}

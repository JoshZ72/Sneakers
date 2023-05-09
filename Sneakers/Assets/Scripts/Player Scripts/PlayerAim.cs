using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{

    public int rotationSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction to look at the mouse cursor
        Vector3 direction = mousePos - transform.position;
        direction.z = 0f;

        // Rotate the object to face the mouse cursor
        transform.up += direction.normalized * rotationSpeed * Time.deltaTime;
    }
}

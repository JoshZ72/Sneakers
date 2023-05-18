using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanHead : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name.Equals("Player"))
        {
            GameObject player = collider.gameObject;
            PlayerHealth health = player.GetComponent<PlayerHealth>();
            health.hasHead = true;
            Destroy(gameObject);
        }

    }
}

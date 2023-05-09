using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleInput : MonoBehaviour
{
    private float vInput;
    private float hInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");
    }

    public float ReturnVInput()
    {
        return vInput;
    }

    public float ReturnHInput()
    {
        return hInput;
    }
}

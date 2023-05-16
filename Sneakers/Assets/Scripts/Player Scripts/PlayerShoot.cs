using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float offset;

    public GameObject projectile;
    public Transform shootPoint;
    public Quaternion spawnRotation;

    private float timebtwShots;
    public float startTimebtwShots;

    void Start()
    {

    }


    private void Update()
    {
        if (timebtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                
                Instantiate(projectile, shootPoint.position, shootPoint.rotation);
                timebtwShots = startTimebtwShots;
            }

        }
        else
        {
            timebtwShots -= Time.deltaTime;
        }
    }



}
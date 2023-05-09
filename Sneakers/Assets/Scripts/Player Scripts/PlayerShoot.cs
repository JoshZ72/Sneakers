using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float offset;

    public GameObject projectile;
    public Transform shotpoint;
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

            //Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            //float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset);

            if (Input.GetMouseButton(0))
            {
                Instantiate(projectile, shotpoint.position, shotpoint.rotation);
                timebtwShots = startTimebtwShots;
            }

        }
        else
        {
            timebtwShots -= Time.deltaTime;
        }
    }



}


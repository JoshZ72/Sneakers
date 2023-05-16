using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCombat : MonoBehaviour
{
    private float pDistance;
    private GameObject player;
    public float moveSpeed;
    public float rotationSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public GameObject bulletPrefab;
    [SerializeField] private Transform FiringPoint;
    private bool canShoot;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = this.GetComponent<Rigidbody2D>();
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {

        pDistance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        /*
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = ((angle - 90));
        direction.Normalize();
        movement = direction;
        */


        if (timeBtwAttack <= 0)
        {
            canShoot = true;
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
        if (pDistance < 4)
        {
            Quaternion pRotate = Quaternion.Euler((Vector3.forward * (angle - 90)));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, pRotate, (rotationSpeed * 10) * Time.deltaTime);

            if (canShoot)
            {
                Shoot();
                canShoot = false;
            }
        }
        else if (pDistance < 10)
        {

            Quaternion pRotate = Quaternion.Euler((Vector3.forward * (angle - 90)));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, pRotate, (rotationSpeed * 8) * Time.deltaTime);

            MoveCharacter(movement);
            if (canShoot)
            {
                Shoot();
                canShoot = false;
            }
        }
        else if (pDistance > 11)
        {
            this.GetComponent<NPCCombat>().enabled = false;
        }
    }

    private void FixedUpdate()
    {

    }

    void MoveCharacter(Vector2 direction)
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, FiringPoint.position, FiringPoint.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileScript : MonoBehaviour
{
    public float speed = 10;
    public float lifeTime = 2f;
    public int damage;

    public GameObject destroyEffect;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }


    private void Update()
    {
        transform.position += speed * transform.up* Time.deltaTime;
    }

    void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.TakeDamage(damage);
            Destroy(gameObject);
        }

        /*
        if (collision.gameObject.tag.Equals("Player"))
        {
            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
            health.TakeDamage(damage);
            Destroy(gameObject);
        }
        */

        /*
        if (collision.gameObject.tag.Equals("Boss"))
        {
            if (collision.gameObject.GetComponent<BossHealth>() != null)
            {
                BossHealth health = collision.gameObject.GetComponent<BossHealth>();
                health.TakeDamage(damage);
            }
        }
        */
        Destroy(gameObject);
    }
}

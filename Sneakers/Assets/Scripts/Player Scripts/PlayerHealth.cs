using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    public Quest quests;

    private Animator animator;

    public Slider healthbar;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.value = currentHealth;

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("YouDied");
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            //SceneManager.LoadScene("cRED");
        }

    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }


}

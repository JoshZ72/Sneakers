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
    
    public bool hasHead;

    public int keyItems;

    void Start()
    {
        keyItems = 0;
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
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void AddKeyItem()
    {
        keyItems++;
    }
}

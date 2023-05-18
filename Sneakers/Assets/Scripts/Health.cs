using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    public GameObject happyCont;
    private HappyController happiness;

    private Animator animator;
    public GameObject head;
    public Slider healthbar;


    void Start()
    {
        currentHealth = maxHealth;
        happiness = happyCont.GetComponent<HappyController>();
    }


    void Update()
    {

        healthbar.value = currentHealth;

        if (currentHealth <= 0)
        {
            if (this.tag.Equals("Cyborg"))
            {
                happiness.AddHumanHappiness(5);
            }
            else if (this.tag.Equals("Human"))
            {
                happiness.AddCyborgHappiness(5);
                if (gameObject.GetComponent<HumanQuest>() != null)
                {
                    head.SetActive(true);
                }
            }
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
}

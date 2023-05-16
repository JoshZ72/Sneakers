using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index = 0;
    public Quest quest;
    public PlayerHealth player;

    public float wordSpeed;
    public bool playerIsClose;
    private bool hasTalkedTo;
    private float pDistance;

    public GameObject happyCont;
    private HappyController happiness;


    void Start()
    {
        dialogueText.text = "";
        happiness = happyCont.GetComponent<HappyController>();
    }

    // Update is called once per frame
    void Update()
    {
        pDistance = Vector2.Distance(transform.position, player.transform.position);
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (!dialoguePanel.activeInHierarchy)
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
            else if (dialogueText.text == dialogue[index])
            {
                NextLine();
            }

        }
        else if (Input.GetKeyDown(KeyCode.Q) && dialoguePanel.activeInHierarchy)
        {
            dialogueText.text = "";
            RemoveText();
        }

        if (pDistance < 10)
        {
            if (this.tag.Equals("Cyborg"))
            {
                if (happiness.GetHappiness() < 40)
                {

                }
            }
            else if(this.tag.Equals("Human"))
            {
                if (happiness.GetHappiness() > 60)
                {
                    this.GetComponent<NPCCombat>().enabled = true;
                }
            }
        }
    }

    public void RemoveText()
    {
        index = 0;
        dialogueText.text = "";
        
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            if (!hasTalkedTo)
            {

            }
            hasTalkedTo = true;
            RemoveText();
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            RemoveText();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("PBullet"))
        {
            this.GetComponent<NPCCombat>().enabled = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Loadlevel1()
    {
        SceneManager.LoadScene("Story_Intro");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();

    }

    public void Credits()
    {
        Debug.Log("CREDITS");
        SceneManager.LoadScene("credits");


    }


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene("Level1");
        }
    }
}

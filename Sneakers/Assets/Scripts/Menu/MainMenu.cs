using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Loadlevel1()
    {
        SceneManager.LoadScene("Sam Scene");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene("Level1");
        }
    }
}

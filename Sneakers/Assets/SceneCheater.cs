using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneCheater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("MainMenu");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("Story_Intro");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("CityScene");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene("Credits");
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SceneManager.LoadScene("HumanEnding");
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SceneManager.LoadScene("TerminatorEnding");
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SceneManager.LoadScene("CyborgEnding");
        }
    }
}

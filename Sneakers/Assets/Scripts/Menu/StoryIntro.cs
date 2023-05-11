using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryIntro : MonoBehaviour
{
    // Start is called before the first frame update

    public void GameStart()
    {
        Debug.Log("Sam Scene");
        SceneManager.LoadScene("Sam Scene");

    }

}

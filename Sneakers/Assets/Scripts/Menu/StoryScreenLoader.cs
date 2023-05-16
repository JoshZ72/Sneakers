using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryScreenLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {

        //Load next scrreen
        SceneManager.LoadScene("CityScene", LoadSceneMode.Single);
        
    }

   
}

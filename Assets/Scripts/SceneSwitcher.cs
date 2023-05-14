using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    public string targetScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.Space))
        {
            switchScene(targetScene);
        }
        */
    }

    public void switchScene(string targetScene)
    {
        SceneManager.LoadScene("Scenes/" + targetScene);
    }
}

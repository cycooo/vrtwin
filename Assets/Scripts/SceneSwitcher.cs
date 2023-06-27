using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string targetScene;


    public void switchScene(string targetScene)
    {
        SceneManager.LoadScene("Scenes/" + targetScene);
    }
}

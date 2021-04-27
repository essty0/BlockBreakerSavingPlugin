using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    

    public void LoadNextScene(int level = 0)
    {
        // FindObjectOfType<GameStatus>().ResetTimer();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if((level + 1) <= SceneManager.sceneCountInBuildSettings) SceneManager.LoadScene(level + 1);
        else SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings);

    }

    public void LoadStartScene()
    {
        FindObjectOfType<GameStatus>().ResetTimer();
        SceneManager.LoadScene(0);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLastScene(){
        SceneManager.LoadScene(3);
    }

  
}

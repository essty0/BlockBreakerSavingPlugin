using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;
    SceneLoader mySceneLoader;   
    SaveManager saveManager;

    GameStatus gameStatus;

    int score;

    public void countBlocks() {
        breakableBlocks++;
    }
    void Start()
    {
        
        mySceneLoader = FindObjectOfType<SceneLoader>();
    }


    public void BlockDestroyed(){
        breakableBlocks--;
        if(breakableBlocks <= 0){
            // int score = GetComponent<TextMeshProUGUI>();
            // Debug.Log("gameStatus" + gameStatus);
            // score = gameStatus.ReturnScore().ToString();
            score = FindObjectOfType<GameStatus>().ReturnScore();
            // score = gameStatus.GetComponent<TextMeshProUGUI>().text;
            // Debug.Log("Username" + username);
            // Debug.Log("Score: " + score);
            // Debug.Log("Level:" + SceneManager.GetActiveScene().buildIndex);
            // saveManager.SaveLevel(SceneManager.GetActiveScene().buildIndex, score);
            bool isSaved = FindObjectOfType<SaveManager>().SaveLevel(SceneManager.GetActiveScene().buildIndex, score);
            if(isSaved)  mySceneLoader.LoadNextScene(SceneManager.GetActiveScene().buildIndex);
            else SceneManager.LoadScene(0);
            

        }
    }
}

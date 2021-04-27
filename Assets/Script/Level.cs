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
            score = FindObjectOfType<GameStatus>().ReturnScore();
            int timer =  FindObjectOfType<GameStatus>().ReturnTimer();
            bool isSaved = FindObjectOfType<SaveManager>().SaveLevel(SceneManager.GetActiveScene().buildIndex, score, timer );
            if(isSaved)  mySceneLoader.LoadNextScene(SceneManager.GetActiveScene().buildIndex);
            else SceneManager.LoadScene(0);
            

        }
    }
}

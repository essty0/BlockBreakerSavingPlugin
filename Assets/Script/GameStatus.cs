using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed =2;
    [SerializeField] int currentScore = 0;

    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] bool isAutoPlayEnabled;

    public TextMeshProUGUI timerText;

    public TextMeshProUGUI activeUserName;
    private int testScore;

    private string activeUser;

    public float timer = 60;

    bool isTimer = false; // start or stop timer
    

    // SaveManager savedData;
    void Start()
    {

        testScore = FindObjectOfType<SaveManager>().GetCurrentScore();
        scoreText.text = testScore.ToString();
        activeUser = FindObjectOfType<SaveManager>().currentUserName();
        activeUserName.text = activeUser;
        timerText.text = timer.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        if(timer > 0)
            startTimer();
        else  {
            StopTimer();
            FindObjectOfType<SceneLoader>().LoadLastScene();
        }
        
        if (Input.GetKeyDown(KeyCode.Escape)){
            FindObjectOfType<SceneLoader>().LoadStartScene();
        }
    }

    public void AddToScore(){
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString(); 
    }

   

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
    
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public void ResetTimer(){
        Debug.Log("Reset timer" + timer);
        timer = 60;
    }

        public bool IsAutoPlayEnabled()
        {
            return isAutoPlayEnabled;
        }

    public int ReturnScore(){

        return int.Parse(scoreText.text) + pointsPerBlockDestroyed; 
    }

    public int ReturnTimer(){
        isTimer = false;
        return int.Parse(timerText.text);
    }

    void startTimer(){
        if(timerWork()){
            timer -= Time.deltaTime;
            timerText.text = Mathf.Round(timer).ToString();
        }
       
    }

    public void StopTimer(){
        if(timerWork()){
            isTimer = false;
        }
    }

    private bool timerWork(){
        if(isTimer) return true;
        else return false;
    }

    public void unlockTimer(){
        isTimer = true;
        
    }

    /** +20 sec bonus */ 
    public void addBonusTime(){
        timer = timer + 20;
        timerText.text = timer.ToString();
    }

}

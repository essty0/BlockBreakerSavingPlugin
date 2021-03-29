using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed =2;
    [SerializeField] int currentScore = 0;

    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] bool isAutoPlayEnabled;
    private int testScore;
    

    // SaveManager savedData;
    void Start()
    {

        testScore = FindObjectOfType<SaveManager>().GetCurrentScore();
        scoreText.text = testScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;

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

        public bool IsAutoPlayEnabled()
        {
            return isAutoPlayEnabled;
        }

        public int ReturnScore(){
          
            return int.Parse(scoreText.text) + pointsPerBlockDestroyed; 
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag != "Bonus1" && collision.tag != "Bonus2") {
            // SceneManager.LoadScene("GameOver");
            FindObjectOfType<GameStatus>().StopTimer();
            FindObjectOfType<SceneLoader>().LoadLastScene();
        }
        
    }
}

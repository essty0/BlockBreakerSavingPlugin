using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //configuration parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;   //0 tu nie je preto, ze pivot padla je v strede, takze aby sa to zastavilo hned pri dosiahnuti hrany
    [SerializeField] float maxX = 15f;

    // GameSession theGameSession;
    Ball theBall;

    // Start is called before the first frame update
    void Start()
    {
        
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos; //az toto vyvola zmenu pozicie
    }

    private float GetXPos(){
        if(FindObjectOfType<GameStatus>().IsAutoPlayEnabled()){
            return theBall.transform.position.x;
        }
        else {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }

    /** Hit bonus with paddle */ 
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.tag == "Bonus1"){
            Debug.Log("TIME BONUS");
            FindObjectOfType<GameStatus>().addBonusTime();
            Destroy(other.gameObject);
        }
        if(other.transform.tag == "Bonus2"){
            Debug.Log("SPEED BONUS");
            FindObjectOfType<Ball>().IncreaseSpeed(20.0f, 30.0f);
            Destroy(other.gameObject);
        }
    }


}

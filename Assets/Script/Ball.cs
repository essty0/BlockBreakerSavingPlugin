using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //configuration parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;
    //state
    Vector2 paddleToBallVector; //gap - vzdialenost between ball and paddle

    [SerializeField] float randomFactor = 0.2f;
    bool hasStared = false;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource= GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStared != true)
        {
            LockBallToPadle();
            LaunchOnMouseClick();
        }        
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Debug.Log("MOUSE");
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
            hasStared = true;
            FindObjectOfType<GameStatus>().unlockTimer();
        }       
    }

    private void LockBallToPadle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;    //nastavim novu poziciu lopticky
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f, randomFactor), UnityEngine.Random.Range(0f, randomFactor));
       if(hasStared)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)]; 
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
    }

    public void IncreaseSpeed(float newX, float newY){
        myRigidBody2D.velocity = new Vector2(newX, newY);
    }
}

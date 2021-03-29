using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour

{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkleVFX;
    [SerializeField] int maxHits;

    [SerializeField] Sprite[] hitSprites;


    Level level;
    [SerializeField] int timesHit; 
    
    private void OnCollisionEnter2D(Collision2D other) {
       if(tag == "Breakable")
        {
            HandleHit();
        }


    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        } else {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite(){
        int spriteIndex = timesHit -1 ;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void DestroyBlock(){
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
        FindObjectOfType<GameStatus>().AddToScore();
        TriggerSparklesVFX();
    }

    private void Start()
    {
        CountBreakableBlocks();

       
    }
     private void CountBreakableBlocks()
        {
            level = FindObjectOfType<Level>();
            if (tag == "Breakable")
            {
                
                level.countBlocks();
            }
        }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparkleVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
 
    public Transform dropPoint;
    public GameObject timeBonus;
    public GameObject speedBonus;
    private GameObject _spawnBonus;

    private void Update() {
      

    }

    /** Randomly generate Speed or Time bonus */ 
    public void Drop(){
        float rand = Random.Range(0,10);
        if(rand >= 5)  _spawnBonus = timeBonus;
        else _spawnBonus = speedBonus;
        Debug.Log("RAND " + rand);
        Quaternion spawnRotation = Quaternion.Euler(0,0,0);
        Instantiate(_spawnBonus, dropPoint.position, spawnRotation);
    }

    private void OnCollisionEnter2D(Collision2D other) {

        if(other.gameObject.name == "Ball") Drop();

    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using CodeMonkey.Utils;

public class openPopup : MonoBehaviour
{

    public GameObject Panel;
    public GameObject Buttons;
    // Text errorText;
    
    // Open popup by click on New game
    public void panelOpener(){
        if(Panel != null){
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
            bool isActiveButtons = Buttons.activeSelf;
            Buttons.SetActive(!isActiveButtons);
     
           
        }
    }

}

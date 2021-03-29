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
        // errorText = GameObject.FindWithTag ("ErrorText").GetComponent<Text>() as Text;
        // errorText = GameObject.Find("ErrorText").GetComponent<Text>();
        // errorText.text = "";
        // Debug.Log(errorText.text.Length);
        if(Panel != null){
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
            bool isActiveButtons = Buttons.activeSelf;
            Buttons.SetActive(!isActiveButtons);
     
           
        }
    }

    // Close panel by click on Cancel within popup window
    // private void panelClose(){
    //     if(Panel != null){
    //         bool isActive = Panel.activeSelf;
    //         Panel.SetActive(!isActive);
    //         bool isActiveButtons = Buttons.activeSelf;
    //         Buttons.SetActive(!isActiveButtons);

           
    //     }
    // }


    // [SerializeField] private InputNameWindow popupWindow;
    // private void Start() {
    //     GameObject.Find("NewGameButton").GetComponent<Button>().onClick.AddListener(() => popupWindow.Show());
    //     // Debug.Log(GameObject.Find("NewGameButton").GetComponent<Button>());
    // }
}

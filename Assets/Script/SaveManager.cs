using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;



public class SaveManager : MonoBehaviour
{
    public InputField field;
    public Text errorText;
    
    public string nameFromUser;

    private string testName;
    private string savedName;
    private int level;
 

   

    EasyFileSave myFile;
    EasyFileSave currentFile;

    [System.Serializable]
    public class savedData
    {
        public string username = "";
        public int level = 0;
        public int score = 0;

    }
    List<savedData> userData;
     
    


    // Update is called once per frame
    void Update()
    {
        
    }

    /********** New game button **********/
    private void showInput(){
        // Debug.Log(field.text.ToString());
        
        nameFromUser = field.text.Trim().ToString();
        if(nameFromUser.Length != 0){ // Check if name isn't blank
            myFile = new EasyFileSave(nameFromUser);
            myFile.suppressWarning = false;
         
            /**  Check if username exist */
            if(myFile.Load()){
                Debug.Log("Username already exist");
                errorText.gameObject.SetActive(true);
                errorText.text = "Username already exist!";

            } else {
                /** we are going to save username */ 
                userData = new List<savedData>();
                userData.Add(new savedData {username = nameFromUser, level = 0, score = 0}); // Data set for new user
                myFile.AddSerialized("user", userData);
                myFile.Save();


                /** Save current username in currentUser.dat file */
                currentFile = new EasyFileSave("currentUserFile");
                currentFile.Add("currentUser", nameFromUser);
                currentFile.Save();
                if(myFile.Load() && currentFile.Load()){ // Check if data saved
                    myFile.Dispose(); // Free data
                    currentFile.Dispose();  // Free data
                    FindObjectOfType<SceneLoader>().LoadNextScene();
                } else {
                    Debug.Log("Error while saving! Try again");
                }
            }
            
        } else {
            errorText.gameObject.SetActive(true);
        }
    }

    /********** Load game button **********/
    public void LoadGame(){
        savedName = currentUserName();
        myFile = new EasyFileSave(savedName);
        myFile.suppressWarning = false;
        if(myFile.Load()){
            level = myFile.GetInt("level");
            FindObjectOfType<SceneLoader>().LoadNextScene(level); // Load level from saving

        }else {
            Debug.Log("Doesn't loaded");
        }

    }

    /** Save level before going to next */
    public bool SaveLevel(int level, int score){
        savedName = currentUserName();
        if(savedName != null ){
            myFile = new EasyFileSave(savedName);
            if(myFile.Load()){
                Debug.Log("Level: " + level + " score: " + score + " Name:" + savedName);
                myFile.Add("level", level);
                myFile.Add("score", score);
                if(myFile.Save()) {myFile.Dispose(); return true;}
                else return false;
            } 
        }
        
        return false;
    }


    /** Return current user name from currentUser.dat  */
    private string currentUserName(){
        currentFile = new EasyFileSave("currentUserFile");
        if(currentFile.Load()){
            testName = currentFile.GetString("currentUser");
            return testName;
        } else return null;
      
    }

    public void LoadSavedUserData(){
        
    }

    /********** Getter for Score **********/
    public int GetCurrentScore(){
        savedName = currentUserName();
        if(savedName != null ){
            myFile = new EasyFileSave(savedName);
            if(myFile.Load()){
                return myFile.GetInt("score");
            }
        }
        return 0;
    }

        /********** Getter for Level **********/
    public int GetCurrentLevel(){
        savedName = currentUserName();
        if(savedName != null ){
            myFile = new EasyFileSave(savedName);
            if(myFile.Load()){
                return myFile.GetInt("level");
            }
        }
        return 0;
    }
}

  

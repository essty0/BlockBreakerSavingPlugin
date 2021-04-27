using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TigerForge;
using TMPro;
using UnityEngine.UI;

public class ShowWinners : MonoBehaviour
{

    private Transform entryContainer;
    private Transform entryTemplate;

    private List<ScoreEntry> scoreEntryList;
    private List<Transform> hightScoreEntryTransformList;


    EasyFileSave myFile;
    // [System.Serializable]
    // public class Users
    // {
    //     public string name = "";
    //     public int level = 0;
    //     public int score = 0;
    //     public int timer = 60;
    // }

    // List<Users> users;
    // Start is called before the first frame update
    void Start()
    {
        // GetWinnerList();        
    }

    // private List GetWinnerList (){
        // myFile = new EasyFileSave("user6");
        // if(myFile.Load()){
        //     Debug.Log(myFile.GetInt("timer"));
        // }
        // var path = Application.persistentDataPath + "/";
        // var info = new DirectoryInfo(path);
        // var fileInfo = info.GetFiles();
        // return fileInfo;
        // users = new List<Users>();
        // scoreEntryList = {};
        // foreach (var file in fileInfo) {
        //     // Debug.Log(GetFileNameWithoutExtension(file.Name));
        //     string tmpName = System.IO.Path.GetFileNameWithoutExtension(file.ToString());
        //     // string[] x = file.Name.Split(".");
        //     // Debug.Log("TMP: " + tmpName);
        //     if(tmpName == "currentUserFile") continue;
        //     myFile = new EasyFileSave(tmpName);
        //     myFile.suppressWarning = false;
        //     if(myFile.Load()){
        //         int str=0;
        //         // myFile.GetString("name"), myFile.GetInt("level"), myFile.GetInt("score"), myFile.GetInt("timer"));
        //         str = myFile.GetInt("timer");
        //         // Debug.Log(myFile.GetString("username") + ":username");
        //         scoreEntryList = new List<ScoreEntry>(){
        //             new ScoreEntry{name = myFile.GetString("username"), score = myFile.GetInt("score"), timer = myFile.GetInt("timer")};
        //         };

                
                
        //     } else Debug.Log("Bad with load");


        // }
        

        // Debug.Log(users);
    // }



    private void Awake() {
        entryContainer = transform.Find("EntryContainer");
        entryTemplate = entryContainer.Find("TemplateRow");

        entryTemplate.gameObject.SetActive(false);

        // scoreEntryList = new List<ScoreEntry>(){
        //     new ScoreEntry{name = "Name1", score = 10, timer = 30},
        //     new ScoreEntry{name = "Name1", score = 150, timer = 30},
        //     new ScoreEntry{name = "Name1", score = 20, timer = 30},
        //     new ScoreEntry{name = "Name1", score = 10, timer = 30},
        //     new ScoreEntry{name = "Name1", score = 1440, timer = 30},
        // };

        var path = Application.persistentDataPath + "/";
        var info = new DirectoryInfo(path);
        var fileInfo = info.GetFiles();
        scoreEntryList = new List<ScoreEntry>();
        foreach (var file in fileInfo) {
            // Debug.Log(GetFileNameWithoutExtension(file.Name));
            string tmpName = System.IO.Path.GetFileNameWithoutExtension(file.ToString());
            // string[] x = file.Name.Split(".");
            // Debug.Log("TMP: " + tmpName);
            if(tmpName == "currentUserFile") continue;
            myFile = new EasyFileSave(tmpName);
            myFile.suppressWarning = false;
            if(myFile.Load()){
                Debug.Log("Filename: " + tmpName);
                int str=0;
                // myFile.GetString("name"), myFile.GetInt("level"), myFile.GetInt("score"), myFile.GetInt("timer"));
                str = myFile.GetInt("timer");
                // Debug.Log(myFile.GetString("username") + ":username");
                if(myFile.GetString("username") != ""){
                    scoreEntryList.Add(new ScoreEntry{name = myFile.GetString("username"), score = myFile.GetInt("score"), timer = myFile.GetInt("timer")});
                }
                
 
                
            } else {
                Debug.Log("Bad with load");
            }


        }

        /** Sorting by timer */
        for (int i = 0; i < scoreEntryList.Count; i++)
        {
            for (int j = i+1; j < scoreEntryList.Count; j++){
                if(scoreEntryList[j].timer > scoreEntryList[i].timer){
                    ScoreEntry tmp = scoreEntryList[i];
                    scoreEntryList[i] = scoreEntryList[j];
                    scoreEntryList[j] = tmp;
                }
            }
        }

        hightScoreEntryTransformList = new List<Transform>();
        foreach (ScoreEntry highscoreEntry in scoreEntryList)
        {
            CreateScoreEntryTransform(highscoreEntry, entryContainer, hightScoreEntryTransformList);
        }
    }

    /** Generator for 1 winner row */ 
    private void CreateScoreEntryTransform(ScoreEntry scoreEntry, Transform container, List<Transform> transformList){
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -50.0f * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        entryTransform.Find("playerNumber").GetComponent<Text>().text = rank.ToString();
        entryTransform.Find("PlayerName").GetComponent<Text>().text = scoreEntry.name;
        entryTransform.Find("PlayerScore").GetComponent<Text>().text = scoreEntry.score.ToString();
        entryTransform.Find("PlayerTime").GetComponent<Text>().text = scoreEntry.timer.ToString();
        transformList.Add(entryTransform);
    }

    /** Single score entry */ 
    [System.Serializable]
    public class ScoreEntry{
        public string name;
        public int score;
        public int timer;
    }
}

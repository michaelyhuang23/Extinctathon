using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CodeNameManager : MonoBehaviour{
    public class User{
        static public int cutoff = 3000;

        public string username;
        public int rating;
        public bool isGM;

        public User(string name){
            username = name;
            rating = 0;
            isGM = false;
        }

        public User(string name, int rate){
            username = name;
            setRating(rate);
        }

        public void setRating(int rate){
            rating = rate;
            if(rating >= cutoff) isGM = true;
            else isGM = false;
        }

        public void changeRating(int rate){
            rating += rate;
            if(rating >= cutoff) isGM = true;
            else isGM = false;
        }
    }

    private Dictionary<string, User> users;
    static public User chosenUser;
    [SerializeField] private TMP_InputField input;

    public void Start(){
        User Crake = new User("CRAKE", 3813);
        User Oryx = new User("ORYX", 1857);
        User Thickney = new User("THICKNEY", 1305);
        users = new Dictionary<string, User>(){
            { "CRAKE", Crake },
            { "ORYX", Oryx },
            { "THICKNEY", Thickney }
        }; 
        gameObject.SetActive(false);
    }
    public void DisplayMenu(){
        gameObject.SetActive(true);
    }
    public void EnterPlayRoom(){
        string username = input.text.ToUpper();
        print(username);
        if(username == string.Empty) return;
        if(users.ContainsKey(username)){
            chosenUser = users[username];
            SceneManager.LoadScene("GameScene");
        }else{
            chosenUser = new User(username);
            users.Add(username, chosenUser);
            SceneManager.LoadScene("GameScene");
        }
    }
    public void Update(){
        if (Input.GetKeyDown(KeyCode.Return))
            EnterPlayRoom();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UserData;

public class CodeNameManager : MonoBehaviour{
    

    static public User chosenUser;
    [SerializeField] private TMP_InputField input;

    public void Start(){
        gameObject.SetActive(false);
    }
    public void DisplayMenu(){
        gameObject.SetActive(true);
    }
    public void EnterPlayRoom(){
        string username = input.text.ToUpper();
        print(username);
        if(username == string.Empty) return;
        if(User.users.ContainsKey(username)){
            chosenUser = User.users[username];
            SceneManager.LoadScene("GameScene");
        }else{
            chosenUser = new User(username);
            User.users.Add(username, chosenUser);
            print("creation new user "+User.users.Count);
            SceneManager.LoadScene("GameScene");
        }
    }
    public void Update(){
        if (Input.GetKeyDown(KeyCode.Return))
            EnterPlayRoom();
    }
}

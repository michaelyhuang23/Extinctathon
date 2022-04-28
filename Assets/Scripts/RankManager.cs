using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UserData;

public class RankManager : MonoBehaviour
{
    [SerializeField] private GameObject userObj, userContainer;
    void Start(){
        if(User.users==null){
            User Crake = new User("CRAKE", 3813);
            User Oryx = new User("ORYX", 1857);
            User Thickney = new User("THICKNEY", 1305);
            User Michael = new User("MICHAEL", 4019);
            User.users = new Dictionary<string, User>(){
                { "CRAKE", Crake },
                { "ORYX", Oryx },
                { "THICKNEY", Thickney },
                { "MICHAEL", Michael }
            }; 
        }

        print(User.users.Count);

        DisplayRank();
    }


    void createRow(string textEntry){
        GameObject newUser = Instantiate(userObj) as GameObject;
        newUser.transform.SetParent(userContainer.transform);
        newUser.transform.localScale = new Vector3(1,1,1);
        newUser.GetComponent<TMP_Text>().text = textEntry;
    }

    void DisplayRank(){
        List<User> users = new List<User>();
        foreach(KeyValuePair<string, User> entry in User.users){
            users.Add(entry.Value);
        }
        users.Sort((x,y)=>-x.rating.CompareTo(y.rating));
        for(int i=0;i<users.Count;i++){
            createRow("#"+(i+1)+" "+users[i].username+": "+users[i].rating);
        }

    }

}

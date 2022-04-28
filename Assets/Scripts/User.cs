using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UserData{

public class User{
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

    static public int cutoff = 3000;
    static public Dictionary<string, User> users;
}

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UserData;
using MammalData;

public class GameExitManager : MonoBehaviour
{
    [SerializeField] private TypeWriterEffect titleWriter, infoWriter;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private InputManager gamecenter;
    [SerializeField] private PointManager pointcounter;
    [SerializeField] private GameObject gamefield;
    private User user;
    private Mammal bioform;
    private int point;
    void Start(){
        gameObject.SetActive(false);
    }

    public void BeginExit(bool win){
        gameObject.SetActive(true);
        user = CodeNameManager.chosenUser;
        point = pointcounter.point;
        if(!win) point = 0;
        if(user==null) user = new User("Anonymous", 0);
        bioform = gamecenter.answerAnimal;
        gamefield.SetActive(false);
        if(win){
            if(user.isGM){
                titleWriter.TypeText("Maddaddam: Congratulations Grandmaster "+user.username);
            }else{
                titleWriter.TypeText("Maddaddam: Congratulations "+user.username);
            }
        }else{
            if(user.isGM){
                titleWriter.TypeText("Maddaddam: You failed, Grandmaster "+user.username);
            }else{
                titleWriter.TypeText("Maddaddam: You failed, "+user.username);
            }
        }


        scoreText.text = "rating: "+user.rating;
        StartCoroutine(ratingAnimation(scoreText, user.rating, point, 0.1f));

        infoWriter.TypeText("Maddaddam: Bioform "+bioform.genString()+" is also known as the "+bioform.commonName+". "+bioform.description);
    }

    static public IEnumerator ratingAnimation(TMP_Text textEntry, int start, int change, float rate){
        float timespan = rate * (float)change;
        float time = 0f;
        int npoint = 0;
        while(time < timespan){
            time += Time.deltaTime;
            npoint = start + (int)(time/rate);
            textEntry.text = "rating: " + npoint;
            yield return null;
        }
        npoint = start + change;
        textEntry.text = "rating: " + npoint + "   +" +change;
    }

    public void NewGame(){
        user.rating += point;
        SceneManager.LoadScene("GameScene");
    }
    public void ReturnToMenu(){
        user.rating += point;
        SceneManager.LoadScene("StartMenu");
    }
}

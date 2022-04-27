using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int point;
    public int max_point;
    [SerializeField] private Color32 lowC, highC;
    [SerializeField] private float animate_time = 1f;

    void Start(){
        point = max_point;
        gameObject.GetComponent<TMP_Text>().text = "Current Point:  "+point;
        gameObject.GetComponent<TMP_Text>().color = highC;
    }

    public void setPoint(int point_){
        point = point_;
        gameObject.GetComponent<TMP_Text>().text = "Current Point:  "+point;
        Color32 targetC = Color.Lerp(lowC, highC, (float)point/(float)max_point);
        pointAnimation(gameObject.GetComponent<TMP_Text>(), gameObject.transform, targetC, animate_time);
    }

    void pointAnimation(TMP_Text textEntry, Transform textTransform, Color32 targetColor, float timespan){
        Color32 oldColor = textEntry.color;
        Quaternion originalRot = textTransform.rotation; 
        float time = 0f;
        while(time < timespan){
            time += Time.deltaTime;
            textEntry.color = Color.Lerp(oldColor, targetColor, time/timespan);
            textTransform.rotation = originalRot * Quaternion.Euler(0,time/timespan*360,0);
        }

        textTransform.rotation = originalRot;
    }
}

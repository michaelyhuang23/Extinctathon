using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CustomAnimation;

public class PointManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int point;
    public int max_point;
    [SerializeField] private Color32 lowC, highC;
    [SerializeField] private float animate_time = 1f;
    [SerializeField] private ExitManager exiter;

    void Start(){
        point = max_point;
        gameObject.GetComponent<TMP_Text>().text = "+"+point;
        gameObject.GetComponent<TMP_Text>().color = highC;
    }

    public void setPoint(int point_){
        point = point_;
        gameObject.GetComponent<TMP_Text>().text = "+"+point;
        Color32 targetC = Color.Lerp(lowC, highC, (float)point/(float)max_point);
        StartCoroutine(CodeAnimator.rotateAnimation(transform, 360,0,0 , animate_time));
        StartCoroutine(CodeAnimator.colorAnimation(gameObject.GetComponent<TMP_Text>(), targetC, animate_time));

        if(point == 0)
            exiter.ExitPlayRoom();
    }

}

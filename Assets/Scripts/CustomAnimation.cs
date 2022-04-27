using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CustomAnimation{

public class CodeAnimator{

    static public IEnumerator rotateAnimation(Transform textTransform, int degx, int degy, int degz, float timespan){
        Quaternion originalRot = textTransform.rotation; 
        float time = 0f;
        while(time < timespan){
            time += Time.deltaTime;
            textTransform.rotation = originalRot * Quaternion.Euler(time/timespan*degx,time/timespan*degy,time/timespan*degz);

            yield return null;
        }
        textTransform.rotation = originalRot * Quaternion.Euler(degx,degy,degz);
    }

    static public IEnumerator colorAnimation(TMP_Text textEntry, Color32 targetColor, float timespan){
        Color32 oldColor = textEntry.color;
        float time = 0f;
        while(time < timespan){
            time += Time.deltaTime;
            textEntry.color = Color.Lerp(oldColor, targetColor, time/timespan);
            yield return null;
        }
        textEntry.color = targetColor;
    }

}

}
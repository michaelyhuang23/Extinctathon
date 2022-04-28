using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{

   [SerializeField] private float speed = 2f;
   [SerializeField] private string defaultText = "";
   [SerializeField] private TMP_Text textEntry;

   public void Start(){
      if(defaultText != string.Empty){
         TypeText(defaultText, textEntry);
      }
   }

   public void TypeText(string text, TMP_Text txtObj){
      StartCoroutine(typeCharacters(text, txtObj));
   }

   public void TypeText(string text){
      TypeText(text, gameObject.GetComponent<TMP_Text>());
   }

   private IEnumerator typeCharacters(string text, TMP_Text txtObj){
      float t = 0;
      int charIndex = 0;
      int pcharIndex = -1;
      while(charIndex < text.Length){
         if(charIndex > pcharIndex){
            txtObj.text += text.Substring(pcharIndex+1, charIndex-pcharIndex);
            pcharIndex = charIndex;
         }

         t += Time.deltaTime * speed;
         charIndex = (int)t;

         yield return null;
      }
      print("type finished");
   }
}

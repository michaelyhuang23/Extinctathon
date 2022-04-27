using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroManager : MonoBehaviour
{
    public string introText = "Corknut: This gigantic mammal has four legs and went extinct in 2056.";
    [SerializeField] private TMP_Text textfield;
    [SerializeField] private GameObject glitcher;
    public void DisplayIntro(string txt){
        introText = txt;
        textfield.text = "";
        gameObject.GetComponent<TypeWriterEffect>().TypeText(introText, textfield);
        StartCoroutine(slowGlitch());
    }

    IEnumerator slowGlitch(){
        yield return new WaitForSeconds(3);
        glitcher.GetComponent<GlitchEffect>().intensity = 0.2f;
        glitcher.GetComponent<GlitchEffect>().flipIntensity = 0.2f;
        glitcher.GetComponent<GlitchEffect>().colorIntensity = 0.4f;
    }
}

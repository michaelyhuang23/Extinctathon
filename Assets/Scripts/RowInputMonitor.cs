using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using MammalData;
using CustomAnimation;


public class RowInputMonitor : MonoBehaviour
{
    [SerializeField] private GameObject order, family, genus, species;
    [SerializeField] private GameObject orderT, familyT, genusT, speciesT;
    private TMP_InputField orderF, familyF, genusF, speciesF;
    private Mammal output;


    void Start(){
        orderF = order.GetComponent<TMP_InputField>();
        familyF = family.GetComponent<TMP_InputField>();
        genusF = genus.GetComponent<TMP_InputField>();
        speciesF = species.GetComponent<TMP_InputField>();
    }

    public Mammal readInput(){
        output = new Mammal();
        output.order = orderF.text.ToLower();
        output.family = familyF.text.ToLower();
        output.genus = genusF.text.ToLower();
        output.species = speciesF.text.ToLower();

        if(!output.isValid()) {
            showInvalid();
            return null;
        }
        disableInput();
        return output;
    }

    void showInvalid(){
        float timespan = 0.02f;
        if(!output.isOrderValid())
            StartCoroutine(jerkAnimation(order.transform, timespan));
        StartCoroutine(jerkAnimation(family.transform, timespan));
        StartCoroutine(jerkAnimation(genus.transform, timespan));
        StartCoroutine(jerkAnimation(species.transform, timespan));
    }

    IEnumerator jerkAnimation(Transform textTransform, float timespan){
        Quaternion originalRot = textTransform.rotation; 
        float time = 0f;
        while(time < timespan){
            time += Time.deltaTime;
            textTransform.rotation = originalRot * Quaternion.Euler(0,0,time/timespan*10);
            yield return null;
        }
        time = 0f;
        while(time < 2*timespan){
            time += Time.deltaTime;
            textTransform.rotation = originalRot * Quaternion.Euler(0,0,10) * Quaternion.Euler(0,0,-time/(2*timespan)*20);
            yield return null;
        }
        time = 0f;
        while(time < timespan){
            time += Time.deltaTime;
            textTransform.rotation = originalRot * Quaternion.Euler(0,0,-10) * Quaternion.Euler(0,0,time/(timespan)*10);
            yield return null;
        }

        textTransform.rotation = originalRot;
    }

    public void disableInput(){
        orderF.enabled = false;
        familyF.enabled = false;
        genusF.enabled = false;
        speciesF.enabled = false;

        orderT.GetComponent<TMP_Text>().text = output.order;
        familyT.GetComponent<TMP_Text>().text = output.family;
        genusT.GetComponent<TMP_Text>().text = output.genus;
        speciesT.GetComponent<TMP_Text>().text = output.species;
    }

    void markGreen(GameObject obj){
        Color32 targetC = new Color32(9,255,0,235);
        StartCoroutine(CodeAnimator.colorAnimation(obj.GetComponent<TMP_Text>(), targetC, 1));
        StartCoroutine(CodeAnimator.rotateAnimation(obj.transform, 0,360,0, 1));
    }

    void markRed(GameObject obj){
        Color32 targetC = new Color32(255,0,9,235);
        StartCoroutine(CodeAnimator.colorAnimation(obj.GetComponent<TMP_Text>(), targetC, 1));
        StartCoroutine(CodeAnimator.rotateAnimation(obj.transform, 0,360,0 , 1));
    }

    public void markInput(Mammal refe){
        if(refe.matchOrder(output)) markGreen(orderT);
        else markRed(orderT);

        if(refe.matchFamily(output)) markGreen(familyT);
        else markRed(familyT);

        if(refe.matchGenus(output)) markGreen(genusT);
        else markRed(genusT);

        if(refe.matchSpecies(output)) markGreen(speciesT);
        else markRed(speciesT);
    }

}

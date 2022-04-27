using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using MammalData;


public class RowInputMonitor : MonoBehaviour
{
    [SerializeField] private GameObject order, family, genus, species;
    [SerializeField] private GameObject orderT, familyT, genusT, speciesT;
    private TMP_InputField[] inputfields;
    private TMP_InputField orderF, familyF, genusF, speciesF;
    private Mammal output;


    void Start(){
        orderF = order.GetComponent<TMP_InputField>();
        familyF = family.GetComponent<TMP_InputField>();
        genusF = genus.GetComponent<TMP_InputField>();
        speciesF = species.GetComponent<TMP_InputField>();
        inputfields = new TMP_InputField[4]{orderF, familyF, genusF, speciesF};
    }

    public Mammal readInput(){
        output = new Mammal();
        output.order = orderF.text.ToLower();
        output.family = familyF.text.ToLower();
        output.genus = genusF.text.ToLower();
        output.species = speciesF.text.ToLower();

        orderF.enabled = false;
        familyF.enabled = false;
        genusF.enabled = false;
        speciesF.enabled = false;

        orderT.GetComponent<TMP_Text>().text = output.order;
        familyT.GetComponent<TMP_Text>().text = output.family;
        genusT.GetComponent<TMP_Text>().text = output.genus;
        speciesT.GetComponent<TMP_Text>().text = output.species;

        return output;
    }

    void markGreen(GameObject obj){
        Color32 targetC = new Color32(9,255,0,235);
        StartCoroutine(colorAnimation(obj.GetComponent<TMP_Text>(), obj.transform, targetC, 1));
    }

    void markRed(GameObject obj){
        Color32 targetC = new Color32(255,0,9,235);
        StartCoroutine(colorAnimation(obj.GetComponent<TMP_Text>(), obj.transform, targetC, 1));
    }

    IEnumerator colorAnimation(TMP_Text textEntry, Transform textTransform, Color32 targetColor, float timespan){
        Color32 oldColor = textEntry.color;
        Quaternion originalRot = textTransform.rotation; 
        float time = 0f;
        while(time < timespan){
            time += Time.deltaTime;
            textEntry.color = Color.Lerp(oldColor, targetColor, time/timespan);
            textTransform.rotation = originalRot * Quaternion.Euler(0,time/timespan*360,0);

            yield return null;
        }

        textTransform.rotation = originalRot;
    }

    public void markInput(Mammal refe){
        if(refe.order == output.order) markGreen(orderT);
        else markRed(orderT);

        if(refe.family == output.family) markGreen(familyT);
        else markRed(familyT);

        if(refe.genus == output.genus) markGreen(genusT);
        else markRed(genusT);

        if(refe.species == output.species) markGreen(speciesT);
        else markRed(speciesT);
    }

}

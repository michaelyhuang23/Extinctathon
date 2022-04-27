using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class RowInputMonitor : MonoBehaviour
{
    [SerializeField] private GameObject order, family, genus, species;
    [SerializeField] private GameObject orderT, familyT, genusT, speciesT;
    [SerializeField] Sprite blood, forest;
    private TMP_InputField orderF, familyF, genusF, speciesF;
    private Dictionary<string, string> output;


    void Start(){
        orderF = order.GetComponent<TMP_InputField>();
        familyF = family.GetComponent<TMP_InputField>();
        genusF = genus.GetComponent<TMP_InputField>();
        speciesF = species.GetComponent<TMP_InputField>();
    }

    public Dictionary<string, string> readInput(){
        output = new Dictionary<string, string>();
        output["Order"] = orderF.text.ToLower();
        output["Family"] = familyF.text.ToLower();
        output["Genus"] = genusF.text.ToLower();
        output["Species"] = speciesF.text.ToLower();

        orderF.enabled = false;
        familyF.enabled = false;
        genusF.enabled = false;
        speciesF.enabled = false;

        orderT.GetComponent<TMP_Text>().text = output["Order"];
        familyT.GetComponent<TMP_Text>().text = output["Family"];
        genusT.GetComponent<TMP_Text>().text = output["Genus"];
        speciesT.GetComponent<TMP_Text>().text = output["Species"];

        return output;
    }

    void markGreen(GameObject obj){
        Color32 targetC = new Color32(9,0,255,235);
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

    public void markInput(Dictionary<string, string> refe){
        if(refe["Order"] == output["Order"]) markGreen(orderT);
        else markRed(orderT);

        if(refe["Family"] == output["Family"]) markGreen(familyT);
        else markRed(familyT);

        if(refe["Genus"] == output["Genus"]) markGreen(genusT);
        else markRed(genusT);

        if(refe["Species"] == output["Species"]) markGreen(speciesT);
        else markRed(speciesT);
    }
}

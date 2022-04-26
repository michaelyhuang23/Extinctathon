using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class RowInputMonitor : MonoBehaviour
{
    [SerializeField] private GameObject order, family, genus, species;
    [SerializeField] private TMP_Text orderT, familyT, genusT, speciesT;
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

        orderT.text = output["Order"];
        familyT.text = output["Family"];
        genusT.text = output["Genus"];
        speciesT.text = output["Species"];

        return output;
    }

    void markGreen(GameObject obj){
        obj.GetComponent<Image>().sprite = forest;
        obj.GetComponent<Image>().color = new Color(50,105,50,195);
    }

    void markRed(GameObject obj){
        obj.GetComponent<Image>().sprite = blood;
        obj.GetComponent<Image>().color = new Color(255,155,155,90);
    }

    public void markInput(Dictionary<string, string> refe){
        if(refe["Order"] == output["Order"]) markGreen(order);
        else markRed(order);

        if(refe["Family"] == output["Family"]) markGreen(family);
        else markRed(family);

        if(refe["Genus"] == output["Genus"]) markGreen(genus);
        else markRed(genus);

        if(refe["Species"] == output["Species"]) markGreen(species);
        else markRed(species);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MammalData;

public class MammalManager : MonoBehaviour
{
    [SerializeField] private TextAsset inputFile, orderFile, familyFile, genusFile, speciesFile;

    void Start(){
        string txt = inputFile.text;
        string[] lines = txt.Split('\n');
        Mammal.mammals = new Mammal[lines.Length];
        for(int i=0;i<lines.Length;i++){
            string line = lines[i];
            string[] cates = line.Split(" # ");
            if(cates.Length != 7)
                print("abnormal length: "+cates.Length);
            Mammal.mammals[i] = new Mammal(cates[0], cates[1], cates[2], cates[3], cates[4], cates[5], cates[6]);
        }


        txt = orderFile.text;
        Mammal.allOrder = txt.Split('\n');

        txt = familyFile.text;
        Mammal.allFamily = txt.Split('\n');

        txt = genusFile.text;
        Mammal.allGenus = txt.Split('\n');

        txt = speciesFile.text;
        Mammal.allSpecies = txt.Split('\n');


        gameObject.GetComponent<InputManager>().enabled = true;
    }

}

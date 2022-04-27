using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MammalData;

public class MammalManager : MonoBehaviour
{
    [SerializeField] private TextAsset inputFile;
    public Mammal[] mammals;

    void Start(){
        string txt = inputFile.text;
        string[] lines = txt.Split('\n');
        mammals = new Mammal[lines.Length];
        for(int i=0;i<lines.Length;i++){
            string line = lines[i];
            string[] cates = line.Split(" # ");
            if(cates.Length != 7)
                print("abnormal length: "+cates.Length);
            mammals[i] = new Mammal(cates[0], cates[1], cates[2], cates[3], cates[4], cates[5], cates[6]);
        }

        gameObject.GetComponent<InputManager>().enabled = true;
    }

}

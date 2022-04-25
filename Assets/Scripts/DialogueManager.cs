using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogue;
    [SerializeField] private string introText = "Adam named the living animals, MaddAddam names the dead ones. Do you want to play?";
    private TypeWriterEffect writer;
    // Start is called before the first frame update
    void Start()
    {
        writer = gameObject.GetComponent<TypeWriterEffect>();
        dialogue.text = "MADDADDAM: ";
        writer.TypeText(introText, dialogue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

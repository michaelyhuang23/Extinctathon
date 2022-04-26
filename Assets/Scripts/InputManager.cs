using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject ViewPort;
    [SerializeField] private GameObject QueryRow;
    [SerializeField] private string order, family, genus, species;
    private Dictionary<string, string> answerkey;
    private List<GameObject> rows;
    public int triesLeft = 10;

    void createRow(){
        GameObject newRow = Instantiate(QueryRow) as GameObject;
        newRow.transform.SetParent(ViewPort.transform);
        newRow.transform.localScale = new Vector3(1,1,1);
        rows.Add(newRow);
    }

    void Start(){
        answerkey = new Dictionary<string, string>();
        order = order.ToLower();
        family = family.ToLower();
        genus = genus.ToLower();
        species = species.ToLower();
        answerkey["Order"] = order;
        answerkey["Family"] = family;
        answerkey["Genus"] = genus;
        answerkey["Species"] = species;
        rows = new List<GameObject>();
        createRow();
    }

    IEnumerator slowExit(){
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("StartMenu");
    }

    void Judge(){
        Dictionary<string, string> input = rows[rows.Count - 1].GetComponent<RowInputMonitor>().readInput();
        if(answerkey["Order"] == input["Order"] && answerkey["Family"] == input["Family"] && answerkey["Genus"] == input["Genus"] && answerkey["Species"] == input["Species"]){
            rows[rows.Count - 1].GetComponent<RowInputMonitor>().markInput(answerkey);
            StartCoroutine(slowExit());
            }else{
                triesLeft--;
                rows[rows.Count - 1].GetComponent<RowInputMonitor>().markInput(answerkey);
                createRow();
            }
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Return))
            Judge();
    }
}

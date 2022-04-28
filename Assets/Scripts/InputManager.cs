using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using MammalData;


public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject ViewPort;
    [SerializeField] private GameObject QueryRow;
    [SerializeField] private GameObject Introducer;
    [SerializeField] private GameObject PointKeeper;
    [SerializeField] private GameExitManager exiter;
    public Mammal answerAnimal;
    private List<GameObject> rows;
    private Mammal[] mammals;
    public int triesLeft = 10;

    public static int animalIndex = 0;

    void createRow(){
        GameObject newRow = Instantiate(QueryRow) as GameObject;
        newRow.transform.SetParent(ViewPort.transform);
        newRow.transform.localScale = new Vector3(1,1,1);
        rows.Add(newRow);
        ViewPort.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rows.Count*200);
    }

    void Start(){
        mammals = Mammal.mammals;
        print("chosen index: "+animalIndex);
        answerAnimal = mammals[animalIndex];
        animalIndex++;
        animalIndex %= mammals.Length;
        Introducer.GetComponent<IntroManager>().DisplayIntro(answerAnimal.hint);
        rows = new List<GameObject>();
        createRow();
    }

    IEnumerator slowExit(){
        yield return new WaitForSeconds(3);
        exiter.BeginExit(true);
    }

    void Judge(){
        Mammal input = rows[rows.Count - 1].GetComponent<RowInputMonitor>().readInput();
        if(input==null) return;
        if(answerAnimal.match(input)){
            rows[rows.Count - 1].GetComponent<RowInputMonitor>().markInput(answerAnimal);
            StartCoroutine(slowExit());
        }else{
            triesLeft--;
            PointKeeper.GetComponent<PointManager>().setPoint(triesLeft);
            rows[rows.Count - 1].GetComponent<RowInputMonitor>().markInput(answerAnimal);
            createRow();
        }
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Return))
            Judge();
    }
}

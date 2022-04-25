using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ExitManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void ExitPlayRoom(){
        SceneManager.LoadScene("StartMenu");
    }
}

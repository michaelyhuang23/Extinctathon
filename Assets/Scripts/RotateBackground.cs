using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBackground : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    // Update is called once per frame
    void Update(){
        transform.Rotate(speed*Time.deltaTime, 0, 0, Space.World);
    }
}

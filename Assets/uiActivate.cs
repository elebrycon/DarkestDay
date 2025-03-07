using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class uiActivate : MonoBehaviour
{
    GameObject canvasCut;
    public void Start()
    {
       canvasCut = GameObject.FindGameObjectWithTag("Cutscene");
        canvasCut.SetActive(false);
        Debug.Log("wwafwedf");
    }
    public void ActivationOfCanvas()
    {
        canvasCut.SetActive(true);
    }
   
}

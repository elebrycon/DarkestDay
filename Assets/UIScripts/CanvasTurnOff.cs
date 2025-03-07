using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasTurnOff : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject AltCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void changeCanvas()
    {
        Canvas.SetActive(false);
        AltCanvas.SetActive(true);
    }
}

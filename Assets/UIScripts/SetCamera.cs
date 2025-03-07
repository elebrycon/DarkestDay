using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class SetCamera : MonoBehaviour
{
    public Canvas canvas;
    private CameraTranstition transtition;
    // Start is called before the first frame update
    void Start()
    {
        transtition = canvas.GetComponent<CameraTranstition>();
    }

    // Update is called once per frame
    public void UpdateCamera(CinemachineVirtualCamera target)
    {
        transtition.currentCamera = target;

    }
}

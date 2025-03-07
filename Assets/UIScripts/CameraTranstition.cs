using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTranstition : MonoBehaviour
{
    //public GameObject Canvas;
    public CinemachineVirtualCamera currentCamera;
    // Start is called before the first frame update
    public void Start()
    {
        //currentCamera.Priority++;
    }

    // Update is called once per frame
    public void UpdateCamera(CinemachineVirtualCamera target)
    {
        currentCamera.Priority--;
        currentCamera = target;
        currentCamera.Priority++;
        //Canvas.SetActive(false);

    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void QuitGame()
    {
        StartCoroutine(TimerC());
    }

    IEnumerator TimerC()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("quit");
        Application.Quit();
    }
}

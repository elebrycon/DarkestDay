using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        StartCoroutine(TimerC());
    }

    IEnumerator TimerC()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Start");
        SceneManager.LoadSceneAsync(1);
        
    }
}

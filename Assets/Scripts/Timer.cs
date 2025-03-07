using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 120f;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    public GameObject WinScreen;

    private ScoreManager scoreManager;

    void Start()
    {
        timerIsRunning = true;
        scoreManager = FindObjectOfType<ScoreManager>();  // Get reference to the ScoreManager
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                TimerEnded();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TimerEnded()
    {
        StartCoroutine(HandleTimerEnd());
    }

    private IEnumerator HandleTimerEnd()
    {
        WinScreen.SetActive(true);
        scoreText.fontSize = 46;
        AudioListener.pause = true;
        Camera.main.clearFlags = CameraClearFlags.SolidColor;
        Camera.main.backgroundColor = Color.black;
        Camera.main.cullingMask = LayerMask.GetMask();

        // Call the method to save the best score
        scoreManager.SaveBestScoreIfHigher();

        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(1);
    }
}

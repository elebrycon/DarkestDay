using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTextTMP;  // Reference to the TextMeshProUGUI component
    private int score = 0;                // Initial score
    private int bestScore = 0;            // Best score
    private string fileName = "bestScore.txt";  // File name to save the best score

    void Start()
    {
        LoadBestScore();   // Load the best score at the start of the game
        UpdateScoreText(); // Update the UI text with the current and best score
    }

    // Method to add score
    public void AddScore(int points)
    {
        score += points;   // Add points to the score
        UpdateScoreText(); // Update the UI text
    }

    // Method to update the TextMeshPro UI element with the current score
    public void UpdateScoreText()
    {
        scoreTextTMP.text = "Score: " + score.ToString() + "\nBest: " + bestScore.ToString();
    }

    // Method to save the best score to a file
    public void SaveBestScoreToFile()
    {
        string filePath = Path.Combine(Application.dataPath, fileName); // Define the file path

        try
        {
            // Write the best score to a .txt file
            File.WriteAllText(filePath, bestScore.ToString());
            Debug.Log($"Best score saved to {filePath}");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to save best score: " + e.Message);
        }
    }

    // Method to load the best score from a file
    public void LoadBestScore()
    {
        string filePath = Path.Combine(Application.dataPath, fileName); // Define the file path

        if (File.Exists(filePath))
        {
            try
            {
                // Read the best score from the file
                string savedBestScore = File.ReadAllText(filePath);
                bestScore = int.Parse(savedBestScore);
                Debug.Log($"Best score loaded: {bestScore}");
            }
            catch (System.Exception e)
            {
                Debug.LogError("Failed to load best score: " + e.Message);
            }
        }
        else
        {
            Debug.Log("No best score file found. Starting fresh.");
        }
    }

    // Method to compare and save score when timer ends
    public void SaveBestScoreIfHigher()
    {
        if (score > bestScore)   // Compare the current score with the best score
        {
            bestScore = score;   // Update best score if current score is higher
            SaveBestScoreToFile();  // Save the new best score
        }
    }
}

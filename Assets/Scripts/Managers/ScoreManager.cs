using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private int highScore;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    
    public UnityEvent<int> OnScoreChanged = new UnityEvent<int>();
    public UnityEvent<int> OnNewHighScore = new UnityEvent<int>();

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HSCORE");
        highScoreText.text = "High Score: " + highScore;
        OnScoreChanged.AddListener(UpdateScoreText);
        OnNewHighScore.AddListener(UpdateHighScoreText);
    }
    public void IncreaseScore()
    {
        score++;
        OnScoreChanged.Invoke(score);
    }

    public void RegisterHighScore()
    {
        if(score > highScore) // new high score 
        {
            highScore = score;
            OnNewHighScore.Invoke(highScore);
            PlayerPrefs.SetInt("HSCORE", highScore);
            Debug.Log("High Score Updated");

        }
            

    }

    private void UpdateScoreText(int newScore)
    {
        scoreText.text = "Score: " + newScore;

    }

    private void UpdateHighScoreText(int newHighScore) 
    {
        highScoreText.text = "High Score: " + newHighScore;
    }
     
}

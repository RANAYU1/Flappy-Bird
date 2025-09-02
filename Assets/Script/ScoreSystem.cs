using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ScoreSystem : MonoBehaviour
{
    private const string HighScoreKey = "HighScore";

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private int scoreIncreaseAmount;

    private int currentScore;
    private int highScore;
    // Start is called before the first frame update
    private void Start()
    {
        highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        highScoreText.text = highScore.ToString();

        currentScore = 0;
        UpdateScoreVisual();
    }

    // Update is called once per frame
    public void OnDestroy()
    {
        SetHighScore();
        PlayerPrefs.Save();
    }
    public void UpdateScoreVisual()
    {
        scoreText.text = currentScore.ToString();
    }
    public void SetHighScore()
    {
        if (int.Parse(highScoreText.text) < currentScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt(HighScoreKey, highScore);
            highScoreText.text = highScore.ToString();
        }
    }
    public void AddScore()
    {
        currentScore += scoreIncreaseAmount;
        UpdateScoreVisual();
    }
}

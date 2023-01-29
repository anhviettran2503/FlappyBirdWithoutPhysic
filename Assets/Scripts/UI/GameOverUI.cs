using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : Panel
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highestScoreText;
    
    public override void Enable()
    {
        base.Enable();
        var score = GameManager.Instance.Score;
        SetScore(score);
        SetHighestScore(Storage.HighestScore);
    }
    private void SetScore(int _score)
    {
        scoreText.text = "Score: "+_score.ToString();
    }
    private void SetHighestScore(int _score)
    {
        highestScoreText.text = "Highest: " + _score.ToString();
    }
    public void OnClickReMatch()
    {
        GameManager.Instance.ReMatch();
    }
}

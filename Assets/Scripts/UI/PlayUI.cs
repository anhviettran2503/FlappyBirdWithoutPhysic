using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayUI : Panel
{
    [SerializeField] private TextMeshProUGUI scoreText;
    protected override void Start()
    {
        base.Start();
        GameManager.Instance.UpdateScore += SetScore;
    }
    public override void Enable()
    {
        base.Enable(); 
        SetScore(0);
    }
    public void SetScore(int _score)
    {
        scoreText.text = _score.ToString();
    }
    private void OnDestroy()
    {
        if (GameManager.Instance == null) return;
        GameManager.Instance.UpdateScore -= SetScore;
    }
}

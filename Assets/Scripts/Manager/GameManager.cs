using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Events;
public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Player player;
    [SerializeField] private int score;
    private float speed;
    public GameState State { get; private set; }
    public bool IsPlaying => State == GameState.Play;
    public float Speed
    {
        get { return speed; }
        private set
        {
            speed= value;
            UpdateSpeed?.Invoke(speed);
        }
    }
    public int Score => score;
    public Player Player => player;
    public UnityAction<int> UpdateScore;
    public UnityAction<GameState> UpdateState;
    public UnityAction<float> UpdateSpeed;
    private void Start()
    {
        Prepare();
    }
    private void Prepare()
    {
        SetState(GameState.Prepare);
        Speed = 1;
        score = 0;
    }
    public void Play()
    {
        SetState(GameState.Play);
    }
    public void Pause()
    {
        SetState(GameState.Pause);
    }
    public void GameOver()
    {
        SetState(GameState.GameOver);
        if(score> Storage.HighestScore)
        {
            Storage.HighestScore = score;
        }
    }
    public void ReMatch()
    {
        Prepare();
    }
    public void IncScore()
    {
        score++;
        UpdateScore?.Invoke(score);
    }
    private bool SetState(GameState _state)
    {
        if (State == _state) return false;
        State = _state;
        UpdateState?.Invoke(State);
        return true;
    }
}

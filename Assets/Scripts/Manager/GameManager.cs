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
    public float GameSpeed
    {
        get { return speed; }
        private set
        {
            speed = value;
            UpdateSpeed?.Invoke(speed);
        }
    }
    public int Score => score;
    public Player Player => player;
    public UnityAction<int> UpdateScore;
    public UnityAction<GameState> UpdateState;
    public UnityAction<GameState> AfterUpdateState;
    public UnityAction<float> UpdateSpeed;
    private void Start()
    {
        Prepare();
    }
    private void Prepare()
    {
        SetState(GameState.Prepare);
        GameSpeed = 1;
        score = 0;
        AfterSetState();
    }
    public void Play()
    {
        SetState(GameState.Play);
        //Code inside
        AfterSetState();
    }
    public void Pause()
    {
        SetState(GameState.Pause);
        //Code inside
        AfterSetState();
    }
    public void GameOver()
    {
        SetState(GameState.GameOver);
        SoundManager.Instance?.PlaySound(SoundType.Die);
        if (score > Storage.HighestScore)
        {
            Storage.HighestScore = score;
        }
        AfterSetState();
    }
    public void ReMatch()
    {
        Prepare();
        //Code inside
        AfterSetState();
    }
    public void IncScore()
    {
        score++;
        UpdateScore?.Invoke(score);
        IncSpeedByScore();
    }
    private bool SetState(GameState _state)
    {
        if (State == _state) return false;
        State = _state;
        UpdateState?.Invoke(State);
        return true;
    }
    private void AfterSetState()
    {
        AfterUpdateState?.Invoke(State);
    }
    private void IncSpeedByScore()
    {
        if (score > 1 && score % 50 == 0)
        {
            speed += 0.5f;
        }
    }
}

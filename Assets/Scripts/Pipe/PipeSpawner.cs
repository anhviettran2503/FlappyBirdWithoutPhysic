using System;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{

    private Pipe currentPipe;
    private void Start()
    {
        GameManager.Instance.UpdateState += UpdateState;
    }

    private void UpdateState(GameState arg0)
    {
        if (arg0 == GameState.Prepare) currentPipe = null;
    }

    private void Update()
    {
        if (!GameManager.Instance.IsPlaying) return;
        if (currentPipe == null)
        {
            CreatePipe();
            return;
        }
        if (currentPipe.IsEnoughDistance) CreatePipe();
    }
    private void CreatePipe()
    {
        currentPipe = Pool.Instance.GetPipe();
        currentPipe.SetActive();
    }
    private void OnDestroy()
    {
        if (GameManager.Instance == null) return;
        GameManager.Instance.UpdateState += UpdateState;
    }
}

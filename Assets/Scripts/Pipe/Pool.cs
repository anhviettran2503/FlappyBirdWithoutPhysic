using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Pool : Singleton<Pool>
{
    [SerializeField] private Pipe pipePrefab;
    [SerializeField] private int pipeAmount;
    private List<Pipe> pipes;
    private void Start()
    {
        CreatePool();
        GameManager.Instance.UpdateState += UpdateState;
    }
    private void CreatePool()
    {
        pipes = new List<Pipe>();
        for (int i = 0; i < pipeAmount; i++)
        {
            CreatePipe();
        }
    }
    private Pipe CreatePipe()
    {
        var pipe = Instantiate(pipePrefab, transform);
        pipes.Add(pipe);
        return pipe;
    }

    public Pipe GetPipe()
    {
        for (int i = 0; i < pipes.Count; i++)
        {
            if (!pipes[i].Active)
            {
                return pipes[i];
            }
        }
        var pipe = CreatePipe();
        return pipe;
    }
    private void DeActivePipes()
    {
        if (pipes == null || pipes.Count == 0) return;
        pipes.ForEach(x =>
        {
            x.SetDeActive();
        });
    }
    private void UpdateState(GameState arg0)
    {
        if (arg0 == GameState.Prepare) DeActivePipes();
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        if (GameManager.Instance == null) return;
        GameManager.Instance.UpdateState -= UpdateState;
    }


}

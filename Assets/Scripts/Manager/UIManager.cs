using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<Panel> panels;
    private void Start()
    {
        GameManager.Instance.UpdateState += UpdateState;
    }
    private void UpdateState(GameState _state)
    {
        switch (_state)
        {
            case GameState.None:
                break;
            case GameState.Prepare:
                OnPrepare();
                break;
            case GameState.Play:
                OnPlay();
                break;
            case GameState.Pause:
                break;
            case GameState.GameOver:
                OnGameOver();
                break;
            default:
                break;
        }
    }
    private void OnPrepare()
    {
        EnablePanel(PanelType.Prepare);
    }
    private void OnPlay()
    {
        EnablePanel(PanelType.Play);
    }
    private void OnGameOver()
    {
        EnablePanel(PanelType.GameOver);
    }
    private void EnablePanel(PanelType _type)
    {
        panels.ForEach(x =>
        {
            if (x.Type == _type)
            {
                x.Enable();
            }
            else
            {
                x.Disable();
            }
        });
    }
    private void OnDestroy()
    {
        if (GameManager.Instance == null) return;
        GameManager.Instance.UpdateState -= UpdateState;
    }
}

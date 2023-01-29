using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum GameState
{
    None,
    Prepare,
    Play,
    Pause,
    GameOver,
}
[System.Serializable]
public enum PanelType
{
    Prepare,
    GameOver,
    Play,
}

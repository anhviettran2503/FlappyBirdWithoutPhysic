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
[System.Serializable]
public class Sound
{
    public SoundType type;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [Range (1f, 3f)]    
    public float pitch;
    [HideInInspector]
    public AudioSource source;
}
[System.Serializable]
public enum SoundType
{
    Hit,
    Wing,
    Point,
    Die
}

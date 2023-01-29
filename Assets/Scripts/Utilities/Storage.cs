using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Storage
{
    private const string Score = "HighestScore";
    public static int HighestScore
    {
        get
        {
            var score = PlayerPrefs.GetInt(Score);
            return score;
        }
        set
        {
            PlayerPrefs.SetInt(Score, value);
        }
    }
}

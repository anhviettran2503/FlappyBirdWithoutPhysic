using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparingUI : Panel
{
    public void ClickPlayGame()
    {
        GameManager.Instance.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System;

public class Player : MonoBehaviour
{
    private Vector3 playerDefaultPosition;
    private Vector2 size = Vector2.one;
    private Vector2 point;
    public Vector2 Size => size;
    public Vector2 GetPoint()
    {
        point.x = transform.position.x - size.x / 2;
        point.y = transform.position.y - size.y / 2;
        return point;
    }
    private void Awake()
    {
        playerDefaultPosition = transform.position;
    }
    private void Start()
    {
        GameManager.Instance.UpdateState += UpdateState;
    }
    private void UpdateState(GameState arg0)
    {
        if (arg0 == GameState.Prepare) transform.position = playerDefaultPosition;
    }
    private void OnDestroy()
    {
        if (GameManager.Instance == null) return;
        GameManager.Instance.UpdateState -= UpdateState;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.XR;

public class RollGround : MonoBehaviour
{
    [SerializeField] private List<MeshRenderer> meshes;
    [SerializeField] private float speed = 0.1f;
    private float gamespeed;
    private void Start()
    {
        GameManager.Instance.UpdateSpeed += UpdateSpeed;
        GameManager.Instance.UpdateState += UpdateState;
    }
    private void Update()
    {
        if (!GameManager.Instance.IsPlaying) return;
        meshes.ForEach(x =>
        {
            x.material.mainTextureOffset += new Vector2(speed * gamespeed * Time.deltaTime, 0);
        });
    }
    private void UpdateSpeed(float _speed)
    {
        gamespeed = _speed;
    }
    private void UpdateState(GameState arg0)
    {
        if (arg0 == GameState.Prepare)
        {
            meshes.ForEach(x =>
            {
                x.material.mainTextureOffset = Vector2.zero;
            });
        }
    }
    private void OnDestroy()
    {
        if (GameManager.Instance == null) return;
        GameManager.Instance.UpdateSpeed += UpdateSpeed;
        GameManager.Instance.UpdateState -= UpdateState;
    }
}

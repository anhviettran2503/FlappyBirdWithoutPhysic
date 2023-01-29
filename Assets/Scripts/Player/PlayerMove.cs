using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float groundPos = -3.5f;
    private float gravity = -9.8f;
    private float flyFactor = 6;
    private float gravityFactor = 2.5f;
    private float tilt = 5f;

    private Vector3 direction;
    private void Start()
    {
        GameManager.Instance.UpdateState += UpdateState;
    }
    private void UpdateState(GameState arg0)
    {
        if (arg0 == GameState.Prepare)
        {
            direction = Vector3.zero;
        }
    }

    private void Update()
    {
        if (!GameManager.Instance.IsPlaying) return;
        if (Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * flyFactor * GameManager.Instance.GameSpeed;
            PlayWingSound();
        }
        direction.y += gravity * gravityFactor * GameManager.Instance.GameSpeed * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * tilt;
        transform.eulerAngles = rotation;
        if (IsGround()) GameManager.Instance.GameOver();
    }
    private bool IsGround()
    {
        if (transform.position.y < groundPos) return true;
        return false;
    }
    private void PlayWingSound()
    {
        SoundManager.Instance?.PlaySound(SoundType.Wing);
    }
    private void OnDestroy()
    {
        if (GameManager.Instance == null) return;
        GameManager.Instance.UpdateState -= UpdateState;
    }
}

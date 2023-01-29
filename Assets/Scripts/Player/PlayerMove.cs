using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float gravity = -9.8f;
    private float flyFactor = 6;
    private float gravityFactor = 2.5f;
    private float tilt = 5f;

    private Vector3 direction;
    private void Update()
    {
        if (!GameManager.Instance.IsPlaying) return;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * flyFactor;
        }
        direction.y += gravity * gravityFactor * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * tilt;
        transform.eulerAngles = rotation;
    }
}

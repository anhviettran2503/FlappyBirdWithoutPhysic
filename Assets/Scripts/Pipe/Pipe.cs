using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System.Drawing;
using UnityEditor;

public class Pipe : MonoBehaviour
{
    private Player player;

    [SerializeField] private Vector2 clampPipePosition;
    [SerializeField] private float speedFactor;
    [SerializeField] private GameObject topPipe;
    [SerializeField] private GameObject botPipe;
    private Vector2 trans;
    private Vector2 topPoint;
    private Vector2 botPoint;
    private Vector2 pipeSize;
    private Vector2 playerPoint;
    private Vector2 playerSize;

    private float leftPos;
    private float rightPos = 10f;
    private bool active;
    public bool Active => active;
    public bool IsThough { get; private set; }
    private void Start()
    {
        SetDeActive();
        LoadPara();
    }
    private void Update()
    {
        if (!active || !GameManager.Instance.IsPlaying) return;
        transform.position += Vector3.left * GameManager.Instance.Speed * speedFactor * Time.deltaTime;
        if (transform.position.x < leftPos) SetDeActive();
        CheckBirdIntersect();
        CheckBirdThrough();
    }
    private void LoadPara()
    {
        player = GameManager.Instance.Player;
        playerSize = player.Size;
        pipeSize = topPipe.GetComponent<SpriteRenderer>().bounds.size;
        leftPos = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
        rightPos = Mathf.Abs(leftPos) + 5;
    }
    public void CheckBirdIntersect()
    {
        topPoint = topPipe.transform.position;
        topPoint -= pipeSize / 2;
        botPoint = botPipe.transform.position;
        botPoint -= pipeSize / 2;
        playerPoint = player.GetPoint();
        Rect topRect = new Rect(topPoint, pipeSize);
        Rect botRect = new Rect(botPoint, pipeSize);
        Rect playerRect = new Rect(playerPoint, playerSize);
        if (topRect.Overlaps(playerRect) || botRect.Overlaps(playerRect))
        {
            Debug.Log("Game Over");
            GameManager.Instance.GameOver();
        }
    }
    public void CheckBirdThrough()
    {
        playerPoint = player.GetPoint();
        trans = transform.position;
        if (playerPoint.x > trans.x && !IsThough)
        {
            GameManager.Instance.IncScore();
            IsThough = true;
        }
    }
    public void SetDeActive()
    {
        transform.position = new Vector3(rightPos, 0f, -1);
        active = false;
        topPipe.SetActive(false);
        botPipe.SetActive(false);
    }
    public void SetActive()
    {
        active = true;
        IsThough = false;
        var randomY = Random.Range(clampPipePosition.x, clampPipePosition.y);
        transform.position = new Vector3(rightPos, randomY, -1);
        topPipe.SetActive(true);
        botPipe.SetActive(true);
    }
}

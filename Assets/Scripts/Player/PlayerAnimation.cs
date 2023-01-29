using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float duration;
    private float tempCount;
    private int index;
    private void Start()
    {
        tempCount = 0;
    }
    private void Update()
    {
        if (!GameManager.Instance.IsPlaying) return;
        tempCount += Time.deltaTime;
        if (tempCount < duration) return;
        AnimateSprite();
        tempCount = 0;
    }
    private void AnimateSprite()
    {
        index++;

        if (index >= sprites.Length)
        {
            index = 0;
        }
        if (index < sprites.Length && index >= 0)
        {
            spriteRenderer.sprite = sprites[index];
        }
    }
}

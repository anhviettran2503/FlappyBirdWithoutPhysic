using System.Collections;
using System.Collections.Generic;
using System.Data;
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
        GameManager.Instance.UpdateState += UpdateState;
        EnableSprite(false);
    }
    private void UpdateState(GameState arg0)
    {
        if (arg0 == GameState.Prepare)
        {
            EnableSprite(false);
        }
        else
        {
            EnableSprite(true);
        }
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
    private void EnableSprite(bool _enable)
    {
        var sprite = spriteRenderer.gameObject;
        if (sprite == null) return;
        if (sprite.activeInHierarchy != _enable) sprite.SetActive(_enable);
    }
    private void OnDestroy()
    {
        if (GameManager.Instance == null) return;
        GameManager.Instance.UpdateState -= UpdateState;
    }
}

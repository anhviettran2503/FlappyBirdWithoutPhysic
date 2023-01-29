using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    private float spawnDuration = 2f;
    private float currentTime;
    private void Start()
    {
        currentTime = 0;
    }
    private void Update()
    {
        if (!GameManager.Instance.IsPlaying) return;
        currentTime += Time.deltaTime;
        if (currentTime < GameManager.Instance.Speed * spawnDuration) return;
        CreatePipe();
        currentTime = 0;
    }
    private void CreatePipe()
    {
        var pipe = Pool.Instance.GetPipe();
        pipe.SetActive();
    }
}

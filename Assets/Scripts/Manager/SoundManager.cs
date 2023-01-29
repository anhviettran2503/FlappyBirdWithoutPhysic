using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private List<Sound> soundSources;
    protected override void Awake()
    {
        base.Awake();
        soundSources.ForEach(x =>
        {
            x.source = gameObject.AddComponent<AudioSource>();
            x.source.clip = x.clip;
            x.source.volume = x.volume;
            x.source.pitch = x.pitch;
        });
    }
    public void PlaySound(SoundType type)
    {
        var sound = soundSources.Find(x => x.type == type);
        if (sound != null)
        {
            sound.source.Play();
        }
    }
}

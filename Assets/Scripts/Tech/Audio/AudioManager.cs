using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    private AudioSource source;
    private int index = -1;
    private int prevIndex = 0;

    private float leftTime = 1000;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        Events.GameStarted.AddListener(PlayFirstMusic);

        source = GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("mute") == 1) Mute();

        AddressableLoader.inst.musicDone.AddListener(InitMusic, true);
    }

    private void PlayFirstMusic(bool val)
    {
        if (clips != null)
            StartNewAudio();
        else
            index = -2;

        Events.GameStarted.RemoveListener(PlayFirstMusic);
    }

    private void InitMusic(AudioClip[] clips)
    {
        this.clips = clips;

        if (index == -2) StartNewAudio();
    }

    private void Update()
    {
        leftTime -= Time.deltaTime;

        if (leftTime > 0) return;

        StartNewAudio();
    }

    private void StartNewAudio()
    {
        prevIndex = index;
        RollIndex();

        source.clip = clips[index];
        leftTime = source.clip.length;

        source.Play();
    }

    private void RollIndex()
    {
        index = Random.Range(0, clips.Length);

        if (index == prevIndex) RollIndex();
    }

    public void Mute()
    { 
        source.mute = !source.mute;
        PlayerPrefs.SetInt("mute", source.mute ? 1 : 0);
    }
}

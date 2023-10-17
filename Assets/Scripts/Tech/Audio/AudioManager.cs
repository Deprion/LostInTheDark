using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    private AudioSource source;
    private int index = 0;
    private int prevIndex = 0;

    private float leftTime = 100;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        source = GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("mute") == 1) Mute();

        AddressableLoader.inst.musicDone.AddListener(InitMusic, true);
    }

    private void InitMusic(AudioClip[] clips)
    {
        this.clips = clips;

        StartNewAudio();
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

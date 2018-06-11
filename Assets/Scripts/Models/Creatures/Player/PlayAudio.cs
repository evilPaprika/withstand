using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip[] AudioClips;
    public float Volume = 1;

    private AudioSource[] AudioSources;
    private int currentAudioSource = 0;

    void Start()
    {
        // делаем AudioSource из аудиоклипов
        AudioSources = new AudioSource[AudioClips.Length];
        for (var i = 0; i < AudioClips.Length; i++)
        {
            var newAudio = gameObject.AddComponent<AudioSource>();
            newAudio.clip = AudioClips[i];
            newAudio.volume = Volume;
            AudioSources[i] = newAudio;
        }
    }

    void OnEnable() // включается в анимации
    {
        if (AudioSources != null)
            AudioSources[currentAudioSource].Play();
        currentAudioSource = ++currentAudioSource % AudioClips.Length;
    }
}
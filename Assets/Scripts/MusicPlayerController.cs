using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Serialization;

public class MusicPlayerController : MonoBehaviour
{
    //private AudioSource _audioSource;
    //private AudioMixer _gameAudioMixer;
    //private MicrophoneInput _microphoneInput;
    //public RuntimeAudioLoader audioLoader;
    
    public GameObject playIcon;
    public GameObject pauseIcon;    
    public GameObject musicIcon;
    public GameObject microphoneIcon;

    
    public Button playButton;
    public Button pauseButton;
    public Slider volumeSlider;

    private float _previousVolume = 1.0f; // Default volume

    private void Start()
    {
        playButton.onClick.AddListener(Play);
        pauseButton.onClick.AddListener(Pause);
        
        // add keybind T for mic fuck it
    }
    
    void OnDisable()
    {
        playButton.onClick.RemoveListener(Play);
        pauseButton.onClick.RemoveListener(Pause);
    }

    public void PreviousTrack()
    {
        // Implementation goes here
    }

    public void NextTrack()
    {
        // Implementation goes here
    }

    public void Play()
    {
        SingletonDumpster.Instance.audioSource.Play();
        playIcon.SetActive(false);
        pauseIcon.SetActive(true);
    }

    public void Pause()
    {
        SingletonDumpster.Instance.audioSource.Pause();
        playIcon.SetActive(true);
        pauseIcon.SetActive(false);
    }

    public void Mute()
    {
        _previousVolume = SingletonDumpster.Instance.audioSource.volume;
        SingletonDumpster.Instance.audioSource.volume = 0;
    }

    public void Unmute()
    {
        SingletonDumpster.Instance.audioSource.volume = _previousVolume;
    }

    public void VolumeSliderChanged(float value)
    {
        if (value == 0)
            value = Mathf.Epsilon;
        
        SingletonDumpster.Instance.audioMixer.SetFloat("Music", Mathf.Log10(value) * 20);

    }

    public void MicrophoneModeOn()
    {
        // turn on the microphone  != turn off
    }

    public void MusicPlayerOn()
    {
        // this and microphone maybe merge together in a !=
    }

    public void OpenSettings()
    {
        // Implementation goes here
    }

    public void OpenSearch()
    {
        // Implementation goes here
    }
}
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MusicPlayerController : MonoBehaviour, IPointerClickHandler
{
    public GameObject playIcon;
    public GameObject pauseIcon;    
    public GameObject musicIcon;
    public GameObject microphoneIcon;
    public GameObject soundOnIcon;
    public GameObject soundOffIcon;

    public Button playButton;
    public Button pauseButton;
    public Button muteButton;
    public Button unmuteButton;    
    
    public Button musicOnButton;
    public Button microphoneOnButton;
    
    public Slider volumeSlider;
    public Slider trackPositionSlider;
    public Image trackPositionImage;
    private float _previousVolume = 1.0f; // Default volume

    private void Start()
    {
        playButton.onClick.AddListener(Play);
        pauseButton.onClick.AddListener(Pause);
        muteButton.onClick.AddListener(Mute);
        unmuteButton.onClick.AddListener(Unmute);
        volumeSlider.onValueChanged.AddListener(VolumeSliderChanged);

        StartCoroutine(UpdateProgressBar());
    }
    
    private IEnumerator UpdateProgressBar()
    {
        while (true)
        {
            float length = AudioManager.Instance.audioSource.clip.length;
            float progress = AudioManager.Instance.audioSource.time / length;
            trackPositionImage.fillAmount = progress;
            
            yield return new WaitForSeconds(1.0f);
        }
    }
    void OnDisable()
    {
        playButton.onClick.RemoveAllListeners();
        pauseButton.onClick.RemoveAllListeners();
        muteButton.onClick.RemoveAllListeners();
        unmuteButton.onClick.RemoveAllListeners();
        volumeSlider.onValueChanged.RemoveAllListeners();
    }

    public void ChangeTrack(string changeType)
    {
        switch(changeType)
        {
            case "next":
                AudioManager.Instance.audioSource.clip = AudioManager.Instance.audioLoader.SkipTrack("next");
                break;
            case "back":
                AudioManager.Instance.audioSource.clip = AudioManager.Instance.audioLoader.SkipTrack("back");
                break;
            case "shuffle":
                AudioManager.Instance.audioSource.clip = AudioManager.Instance.audioLoader.Shuffle();
                break;
            default:
                Debug.LogError("Invalid changeType!");
                return;
        }
        // Play the new track
        AudioManager.Instance.audioSource.Play();

        // Create the waveform
        AudioManager.Instance.audioLoader.CreateWaveForm(AudioManager.Instance.audioSource.clip);
        
        // Reset fill
        trackPositionImage.fillAmount = 0;
    }


    public void Play()
    {
        AudioManager.Instance.audioSource.Play();
        playIcon.SetActive(false);
        pauseIcon.SetActive(true);
    }

    public void Pause()
    {
        AudioManager.Instance.audioSource.Pause();
        playIcon.SetActive(true);
        pauseIcon.SetActive(false);
    }

    public void Mute()
    {
        _previousVolume = AudioManager.Instance.audioSource.volume;
        AudioManager.Instance.audioSource.volume = 0;
        volumeSlider.value = 0;
        soundOnIcon.SetActive(false);
        soundOffIcon.SetActive(true);
    }

    public void Unmute()
    {
        AudioManager.Instance.audioSource.volume = _previousVolume;
        volumeSlider.value = _previousVolume;
        soundOnIcon.SetActive(true);
        soundOffIcon.SetActive(false);
    }

    public void VolumeSliderChanged(float value)
    {
        AudioManager.Instance.audioSource.volume = value;
        if (value == 0)
        {
            soundOnIcon.SetActive(false);
            soundOffIcon.SetActive(true);
        }
        else
        {
            soundOnIcon.SetActive(true);
            soundOffIcon.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        RectTransform fillRectTransform = trackPositionImage.rectTransform;
    
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(fillRectTransform, eventData.position, eventData.pressEventCamera, out Vector2 localMousePosition))
        {
            float normalizedXPosition = (localMousePosition.x - fillRectTransform.rect.x) / fillRectTransform.rect.width;
            trackPositionImage.fillAmount = Mathf.Clamp01(normalizedXPosition);
    
            float length = AudioManager.Instance.audioSource.clip.length;
            float newTime = Mathf.Clamp(normalizedXPosition * length, 0, length);
            AudioManager.Instance.audioSource.time = newTime;
        }
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
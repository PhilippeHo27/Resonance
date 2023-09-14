using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class RuntimeAudioLoader : MonoBehaviour
{
    private readonly Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();
    private readonly List<string> _audioClipKeys = new List<string>();
    private int _currentIndex = -1;
    private string _musicFolderPath;
    
    private const int MaxSimultaneousLoads = 10;
    private readonly Queue<string> _audioFileQueue = new Queue<string>();
    private int _currentLoads = 0;

    private void Start()
    {
        _musicFolderPath = Path.Combine(Application.dataPath, "Music");
        Directory.CreateDirectory(_musicFolderPath);
        LoadAudioFilesFromFolder();
        CreateWaveForm(AudioManager.Instance.audioSource.clip);
        //AudioManager.Instance.audioSource.Pause();
        
    }

    public void CreateWaveForm(AudioClip clip)
    {
        Texture2D waveform = GenerateWaveform(clip, 2048, 128, Color.clear);
        Rect spriteRect = new Rect(0, 0, waveform.width, waveform.height);
        Vector4 border = new Vector4(10, 10, 10, 10); // Example border values
        Sprite sprite = Sprite.Create(waveform, spriteRect, new Vector2(0.5f, 0.5f), 100, 0, SpriteMeshType.FullRect, border);
        AudioManager.Instance.waveform.sprite = sprite;
    }

    
    private void LoadAudioFilesFromFolder()
    {
        string[] mp3FilePaths = Directory.GetFiles(_musicFolderPath, "*.mp3");
        string[] wavFilePaths = Directory.GetFiles(_musicFolderPath, "*.wav");
        string[] aiffFilePaths = Directory.GetFiles(_musicFolderPath, "*.aiff");
        
        string[] audioFilePaths = mp3FilePaths.Concat(wavFilePaths).Concat(aiffFilePaths).ToArray();

        // Limiting how many coroutines can happen depending on how many files in the music folder
        foreach (string filePath in audioFilePaths)
        {
            _audioFileQueue.Enqueue(filePath);
        }
        
        while (_audioFileQueue.Count > 0 && _currentLoads < MaxSimultaneousLoads)
        {
            StartCoroutine(LoadAudioFile(_audioFileQueue.Dequeue()));
            _currentLoads++;
        }
    }

    private IEnumerator LoadAudioFile(string filePath)
    {
        AudioType audioType;
        string extension = Path.GetExtension(filePath).ToLower();
        switch (extension)
        {
            case ".mp3":
                audioType = AudioType.MPEG;
                break;
            case ".wav":
                audioType = AudioType.WAV;
                break;
            case ".aiff":
                audioType = AudioType.AIFF;
                break;
            default:
                yield break;
        }

        using (UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip("file://" + filePath, audioType))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                string clipName = Path.GetFileNameWithoutExtension(filePath);
                _audioClips.Add(clipName, DownloadHandlerAudioClip.GetContent(request));
                _audioClipKeys.Add(clipName);
            }
            else
            {
                Debug.Log(request.error);
            }
        }

        _currentLoads--;

        // Start the next file loading, if any
        while (_audioFileQueue.Count > 0 && _currentLoads < MaxSimultaneousLoads)
        {
            StartCoroutine(LoadAudioFile(_audioFileQueue.Dequeue()));
            _currentLoads++;
        }
    }

    private Texture2D GenerateWaveform(AudioClip clip, int width, int height, Color color)
    {
        Texture2D texture = new Texture2D(width, height, TextureFormat.RGBA32, false);
        
        // Initialize the texture with clear color
        Color[] clearPixels = new Color[width * height];
        for (int i = 0; i < clearPixels.Length; i++)
        {
            //clearPixels[i] = Color.black;
            clearPixels[i] = new Color(25,25,25,255);
        }
        texture.SetPixels(clearPixels);
        
        float[] samples = new float[clip.samples * clip.channels];
        clip.GetData(samples, 0);
        int stepSize = Mathf.CeilToInt(samples.Length / width);
        float[] waveform = new float[width];

        for (int i = 0; i < width; i++)
        {
            waveform[i] = Mathf.Abs(samples[i * stepSize]);
        }

        int midHeight = height / 2;

        for (int i = 0; i < width; i++)
        {
            // Apply square root scaling
            waveform[i] = Mathf.Sqrt(waveform[i]);

            for (int j = -Mathf.CeilToInt(waveform[i] * midHeight); j < Mathf.CeilToInt(waveform[i] * midHeight); j++)
            {
                texture.SetPixel(i, midHeight + j, color);
            }
        }

        texture.Apply();
        return texture;
    }

    public AudioClip GetAudioClip(string name)
    {
        if (_audioClips.ContainsKey(name))
        {
            return _audioClips[name];
        }
        else
        {
            Debug.LogError($"No audio clip with the name {name} found!");
            return null;
        }
    }

    public AudioClip SkipTrack(string direction)
    {
        if (AudioManager.Instance.audioSource.isPlaying)
        {
            AudioManager.Instance.audioSource.Stop();
        }

        if (direction == "next")
        {
            _currentIndex = (_currentIndex + 1) % _audioClipKeys.Count;
        }
        else if (direction == "back")
        {
            _currentIndex = (_currentIndex - 1 + _audioClipKeys.Count) % _audioClipKeys.Count;
        }

        AudioClip newClip = GetAudioClip(_audioClipKeys[_currentIndex]);
        AudioManager.Instance.audioSource.clip = newClip;
        AudioManager.Instance.audioSource.time = 0;
        AudioManager.Instance.audioSource.Play();

        return newClip;
    }
    
    public AudioClip Shuffle()
    {
        if (_audioClipKeys.Count == 0)
        {
            Debug.LogError("No audio clips loaded!");
            return null;
        }

        _currentIndex = Random.Range(0, _audioClipKeys.Count);
        return GetAudioClip(_audioClipKeys[_currentIndex]);
    }
}

// // Works, generates inner waveform + outer waveform like MusicBee
// private Texture2D GenerateDualWaveform(AudioClip clip, int width, int height, Color color1, Color color2, float compression)
// {
//     Texture2D texture = new Texture2D(width, height, TextureFormat.RGBA32, false);
//     float[] samples = new float[clip.samples * clip.channels];
//     clip.GetData(samples, 0);
//     int stepSize = Mathf.CeilToInt(samples.Length / width);
//     float[] waveform1 = new float[width]; // Outer waveform
//     float[] waveform2 = new float[width]; // Inner waveform
//
//     for (int i = 0; i < width; i++)
//     {
//         float amplitude = Mathf.Abs(samples[i * stepSize]);
//         waveform1[i] = amplitude;
//         waveform2[i] = Mathf.Sqrt(amplitude) * compression;
//     }
//
//     int midHeight = height / 2;
//
//     for (int i = 0; i < width; i++)
//     {
//         // Render outer waveform
//         for (int j = -Mathf.CeilToInt(waveform1[i] * midHeight); j < Mathf.CeilToInt(waveform1[i] * midHeight); j++)
//         {
//             texture.SetPixel(i, midHeight + j, color1);
//         }
//
//         // Render inner waveform on top
//         for (int j = -Mathf.CeilToInt(waveform2[i] * midHeight); j < Mathf.CeilToInt(waveform2[i] * midHeight); j++)
//         {
//             texture.SetPixel(i, midHeight + j, color2);
//         }
//     }
//
//     texture.Apply();
//     return texture;
//     // You can then use the texture wherever you need it
// }
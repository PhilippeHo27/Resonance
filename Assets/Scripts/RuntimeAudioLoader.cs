using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class RuntimeAudioLoader : MonoBehaviour
{
    private Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();

    // This will hold the path to the folder where we'll look for music files
    private string musicFolderPath;
    
    
    private const int MaxSimultaneousLoads = 10;
    private Queue<string> audioFileQueue = new Queue<string>();
    private int currentLoads = 0;
    
    
    private void Start()
    {
        // TODO: RENABLE ONCE YOU WANNA TEST!!!!
        // musicFolderPath = Path.Combine(Application.dataPath, "Music");
        // Directory.CreateDirectory(musicFolderPath);
        
        //load from resource folder
        LoadAllAudioFilesFromResources();
        SingletonDumpster.Instance.audioSource.clip = GetAudioClip("ME_Black_Coffee_Keinemusik_-_The_Rapture_Pt.III_Original_Mix");
        SingletonDumpster.Instance.audioSource.Play();
    }
    

    private void LoadAllAudioFilesFromResources()
    {
        AudioClip[] clips = Resources.LoadAll<AudioClip>("Audio");
        foreach (var clip in clips)
        {
            audioClips.Add(clip.name, clip);
        }
    }
    
    private void LoadAudioFilesFromFolder()
    {
        // Get the full path to each audio file in the folder
        string[] mp3FilePaths = Directory.GetFiles(musicFolderPath, "*.mp3");
        string[] wavFilePaths = Directory.GetFiles(musicFolderPath, "*.wav");
        string[] aiffFilePaths = Directory.GetFiles(musicFolderPath, "*.aiff");

        // Combine the arrays of file paths
        string[] audioFilePaths = mp3FilePaths.Concat(wavFilePaths).Concat(aiffFilePaths).ToArray();

        // Queue each audio file
        foreach (string filePath in audioFilePaths)
        {
            audioFileQueue.Enqueue(filePath);
        }

        // Start the first files loading
        while (audioFileQueue.Count > 0 && currentLoads < MaxSimultaneousLoads)
        {
            StartCoroutine(LoadAudioFile(audioFileQueue.Dequeue()));
            currentLoads++;
        }
    }

    private IEnumerator LoadAudioFile(string filePath)
    {
        // Determine audio type
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
                yield break;  // Skip unknown file types
        }

        using (UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip("file://" + filePath, audioType))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                string clipName = Path.GetFileNameWithoutExtension(filePath);
                audioClips.Add(clipName, DownloadHandlerAudioClip.GetContent(request));
            }
            else
            {
                Debug.Log(request.error);
            }
        }

        currentLoads--;

        // Start the next file loading, if any
        while (audioFileQueue.Count > 0 && currentLoads < MaxSimultaneousLoads)
        {
            StartCoroutine(LoadAudioFile(audioFileQueue.Dequeue()));
            currentLoads++;
        }
    }


    public AudioClip GetAudioClip(string name)
    {
        if (audioClips.ContainsKey(name))
        {
            return audioClips[name];
        }
        else
        {
            Debug.LogError($"No audio clip with the name {name} found!");
            return null;
        }
    }
}
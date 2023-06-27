using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class RuntimeAudioLoader : MonoBehaviour
{
    public AudioSource audioSource;
    private Queue<string> audioPaths = new Queue<string>();
    private bool isPlaying = false;
    public AudioClip audioClip;
    private float[] audioData;

    // private void Start()
    // {
    //     string path = Application.persistentDataPath; // change this to the directory you want
    //     LoadAllAudioFiles(path);
    //
    //     if (audioPaths.Count > 0)
    //         PlayNextAudio();
    //     
    //     // Load the AudioClip
    //     audioClip = Resources.Load<AudioClip>("YourAudioFile"); // Replace with your audio file's name
    //
    //     if (audioClip == null)
    //     {
    //         Debug.LogError("Failed to load AudioClip.");
    //         return;
    //     }
    //
    //     // Fetch the audio data from the clip
    //     audioData = new float[audioClip.samples * audioClip.channels];
    //     audioClip.GetData(audioData, 0);    
    // }

    private void Start()
    {
        
    }

    private void LoadAllAudioFiles(string path)
    {
        var info = new DirectoryInfo(path);
        var fileInfo = info.GetFiles();
        foreach (var file in fileInfo)
        {
            if (file.Extension.ToLower() == ".mp3")
            {
                audioPaths.Enqueue("file://" + file.FullName);
            }
        }
    }

    private void PlayNextAudio()
    {
        if (audioPaths.Count > 0)
        {
            StartCoroutine(LoadAudio(audioPaths.Dequeue(), audioClip =>
            {
                audioSource.clip = audioClip;
                audioSource.Play();
                isPlaying = true;
            }));
        }
    }

    IEnumerator LoadAudio(string path, System.Action<AudioClip> result)
    {
        using (var request = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.MPEG))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                result(DownloadHandlerAudioClip.GetContent(request));
            }
            else
            {
                Debug.Log(request.error);
            }
        }
    }

    private void Update()
    {
        // Check if the song has finished playing, then play the next song
        if (isPlaying && !audioSource.isPlaying)
        {
            isPlaying = false;
            PlayNextAudio();
        }
    }
}

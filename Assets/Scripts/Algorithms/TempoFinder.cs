using System.Collections.Generic;
using UnityEngine;

public class TempoFinder : MonoBehaviour
{
    private Queue<float> _spectralSamples = new();
    private List<float> _beatTimes = new List<float>();
    private float _beatAmount = 0.15f;

    public void Subscribe(AudioProcessor audioProcessor)
    {
        audioProcessor.SpectralFluxData += AnalyzeSpectralFlux;
    }

    private void AnalyzeSpectralFlux(float spectralFlux)
    {
        _spectralSamples.Enqueue(spectralFlux);
        if (_spectralSamples.Count >= 5)
            _spectralSamples.Dequeue();

        float sum = 0f;
        float average;
        foreach (var fluxSample in _spectralSamples)
        {
            sum += fluxSample;
        }

        int count = _spectralSamples.Count;
        average = sum / count;
        
        if (average >= _beatAmount)
        {
            _beatTimes.Add(Time.time);
            SingletonDumpster.Instance.coloring = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, 1.0f);
        }
        
        Debug.Log(ShowBPM());
    }

    private string ShowBPM()
    {
        if (_beatTimes.Count < 2) // We need at least two beats to calculate BPM
        {
            return "Not enough beats to calculate BPM.";
        }

        // Calculate average time difference between beats
        float totalBeatInterval = _beatTimes[^1] - _beatTimes[0];
        float averageBeatInterval = totalBeatInterval / (_beatTimes.Count - 1);

        // Convert beat interval (in seconds) to beats per minute (BPM)
        float bpm = 60f / averageBeatInterval;

        return $"BPM: {bpm}";
    }
}

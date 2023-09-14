using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class TempoFinder : MonoBehaviour
{
    private Queue<float> _spectralSamples = new Queue<float>();
    private Queue<float> _beatTimes = new Queue<float>();
    private float _beatAmount = 0.10f;
    
    private const float MinBeatInterval = 0.24f; // Minimum time in seconds between beats
    private float _timeSinceLastBeat = 0f; // Time in seconds since the last beat

    [SerializeField] TMP_Text text; // TODO HELLO CHANGE THIS NAME PLEASE
    public void Subscribe(AudioProcessor audioProcessor)
    {
        audioProcessor.SpectralFluxData += AnalyzeSpectralFlux;
    }
    
    private void Update()
    {
        _timeSinceLastBeat += Time.deltaTime;
    }

    private void AnalyzeSpectralFlux(float spectralFlux)
    {
        _spectralSamples.Enqueue(spectralFlux);
        if (_spectralSamples.Count > 4)
            _spectralSamples.Dequeue();

        float sum = 0f;
        foreach (var fluxSample in _spectralSamples)
        {
            sum += fluxSample;
        }

        float average = sum / _spectralSamples.Count;

        if (average >= _beatAmount && _timeSinceLastBeat > MinBeatInterval)
        {
            _beatTimes.Enqueue(Time.time);
            if (_beatTimes.Count > 5)
                _beatTimes.Dequeue();

            AudioManager.Instance.coloring = new Color(Random.value, Random.value, Random.value, 1.0f);
            _timeSinceLastBeat = 0f;
        }

        text.text = ShowBPM();
    }

    private string ShowBPM()
    {
        if (_beatTimes.Count < 2) // We need at least two beats to calculate BPM
        {
            return "...";
        }

        // Calculate average time difference between beats
        float totalBeatInterval = _beatTimes.Last() - _beatTimes.First();
        float averageBeatInterval = totalBeatInterval / (_beatTimes.Count - 1);

        // Convert beat interval (in seconds) to beats per minute (BPM)
        float bpm = 60f / averageBeatInterval;

        return $"BPM: {bpm}";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatDetector : IFrequencyAnalyzer
{
    private List<float> _frequenciesToAnalyze; // the audio processor feeds this list

    public void Subscribe(AudioProcessor audioProcessor)
    {
        audioProcessor.FrequencyData += HandleFrequencyDataAvailable;
    }

    private void HandleFrequencyDataAvailable(List<float> frequencies)
    {
        _frequenciesToAnalyze = frequencies;

        // Now we can analyze the frequencies
        Analyze(_frequenciesToAnalyze);
    }
    
    public void Analyze(List<float> frequencies)
    {
        // Implementation of the Analyze method
        // This is where you would put your pattern analysis algorithm
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ColoringFrequencies : IFrequencyAnalyzer
{
    public void Subscribe(AudioProcessor audioProcessor)
    {
        audioProcessor.FrequencyData += HandleFrequencyDataAvailable;
    }

    private void HandleFrequencyDataAvailable(List<float> frequencies)
    {
        // turned off for testing other crap
        //SingletonDumpster.Instance.coloring = Analyze(frequencies);
    }

    public Color Analyze(List<float> frequencies)
    {
        if (!frequencies.Any()) 
        {
            return Color.white; 
        }

        float averageFrequency = frequencies.Average();

        if (averageFrequency < 200)
            return Color.red;
        else if (averageFrequency < 400)
            return Color.yellow;
        else if (averageFrequency < 800)
            return Color.green;
        else if (averageFrequency < 1600)
            return Color.blue;
        else
            return Color.magenta;
    }
}

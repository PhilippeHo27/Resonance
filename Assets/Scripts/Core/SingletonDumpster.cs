using UnityEngine;
using System.Collections.Generic;

public class SingletonDumpster : IndestructibleSingletonBehaviour<SingletonDumpster>
{
    // variables that might be fun to access from anywehere
    public Color coloring;
    public AudioProcessor audioProcessor;
    public float frequencyThresholdTweaker;
    public float spectralFluxOfEntireTrack;
    
    
    
    
    // initalizing algorithms, possible transfer these into a more suitable singleton. Ideally, somehow make it so none of them use gameobjects
    // look at how it was done in the internship examples
    private List<IFrequencyAnalyzer> _algorithms = new List<IFrequencyAnalyzer>();
    [SerializeField] private TempoFinder _tempoFinder;

    protected override void OnSingletonAwake()
    {
        _algorithms.Add(new ColoringFrequencies());

        if (_algorithms.Count != 0)
        {
            foreach (var algorithm in _algorithms)
            {
                algorithm.Subscribe(audioProcessor);
            }
        }

        _tempoFinder.Subscribe(audioProcessor);
    }
}

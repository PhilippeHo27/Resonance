using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Audio;

public class SingletonDumpster : IndestructibleSingletonBehaviour<SingletonDumpster>
{
    public AudioProcessor audioProcessor;
    public MicrophoneInput microphone;
    public RuntimeAudioLoader audioLoader;
    public TempoFinder tempoFinder;
    public AudioSource audioSource;
    public AudioMixer audioMixer;
    
    //variables idk where to put
    [HideInInspector] public float spectralFluxOfEntireTrack;
    public float frequencyThresholdTweaker; // this is to maybe tweak the value for FindSpectralFlux
    public Color coloring;

    
    private List<IFrequencyAnalyzer> _algorithms = new List<IFrequencyAnalyzer>();

    protected override void OnSingletonAwake()
    {
        tempoFinder.Subscribe(audioProcessor);

        //ok this block of crap below is for when / if there's more IFrequencyAnalysers.
        //Before I started this, I thought it was all going to be about frequencies
        //Turns out it's not... so this might be refactored, interface is looking grim.
        _algorithms.Add(new ColoringFrequencies());
        if (_algorithms.Count != 0)
        {
            foreach (var algorithm in _algorithms)
            {
                algorithm.Subscribe(audioProcessor);
            }
        }
    }
}

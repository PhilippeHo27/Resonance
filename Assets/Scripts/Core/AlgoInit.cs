using System;
using System.Collections.Generic;
using UnityEngine;

public class AlgoInit : MonoBehaviour
{
    private List<IFrequencyAnalyzer> _algorithms = new List<IFrequencyAnalyzer>();

    private void Awake()
    {
        _algorithms.Add(new ColoringFrequencies());
        _algorithms.Add(new TempoFinder());

        foreach (var algorithm in _algorithms)
        {
            algorithm.Subscribe(SingleTonDumpsterForNow.Instance.audioProcessor);
        }
        
        
    }
}

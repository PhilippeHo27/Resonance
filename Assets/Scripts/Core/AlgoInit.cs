using System;
using System.Collections.Generic;
using UnityEngine;

public class AlgoInit : MonoBehaviour
{
    private List<IFrequencyAnalyzer> _algorithms = new List<IFrequencyAnalyzer>();

    [SerializeField] private TempoFinder _tempoFinder;
    private void Awake()
    {
        //_algorithms.Add(new ColoringFrequencies());

        if (_algorithms.Count != 0)
        {
            foreach (var algorithm in _algorithms)
            {
                algorithm.Subscribe(SingletonDumpster.Instance.audioProcessor);
            }
        }

        _tempoFinder.Subscribe(SingletonDumpster.Instance.audioProcessor);
    }
}

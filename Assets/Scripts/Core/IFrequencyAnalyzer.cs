using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFrequencyAnalyzer
{
    //void Analyze(List<float> frequencies);
    void Subscribe(AudioProcessor audioProcessor);
}

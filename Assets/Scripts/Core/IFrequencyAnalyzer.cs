// the idea for this class is that i'd instantiate algorithms in a neat way and that I could call " analyze " and it would ping it all
// but the thing is, i found out spectral flux doesn't really need the frequency
// and visualizer can just use the raw spectrum data...
// so right now it's just good for swapping colors depending on frequency range.
public interface IFrequencyAnalyzer
{
    //void Analyze(List<float> frequencies);
    void Subscribe(AudioProcessor audioProcessor);
}

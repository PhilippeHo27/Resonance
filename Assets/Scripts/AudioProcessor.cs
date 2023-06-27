using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
public class AudioProcessor : MonoBehaviour
{

    private const int SampleRate = 44100; //The sample rate is 44100 Hz
    private const int Bins = 8192; // Size of FFT, must be power of 2
    private float[] _spectrum = new float[Bins]; // Buffer for FFT data

    // For the spectrum data from the previous frame
    private List<float> _prevSpectrum = Enumerable.Repeat(0f, Bins).ToList();
    
    public Action<List<float>> FrequencyData;
    public Action<float> SpectralFluxData;
    public Action<float[]> SpectrumData;

    public List<IFrequencyAnalyzer> _algorithm = new(); 
    private void Start()
    {
        StartCoroutine(FindFrequenciesFromFFTCoroutine(FFTWindow.BlackmanHarris));
    }

    private void OnlyFFT(FFTWindow windowType)
    {
        //fast fourier calculations
        AudioListener.GetSpectrumData(_spectrum, 0, windowType);
    }

    public List<float> FindFrequenciesFromFFT()
    {
        List<float> frequencies = new List<float>();

        // Step size for each frequency bin (delta Hz per Bins[i])
        float freqStep = SampleRate / 2f / _spectrum.Length;

        for (int i = 0; i < _spectrum.Length; i++)
        {
            // If there is a significant amount of energy in this frequency bin consider it a detected frequency.
            // This threshold may need adjustment for your specific application.
            if (_spectrum[i] > 0.01f)
            {
                // Compute the frequency for this bin and add it to the list
                float frequency = i * freqStep;
                frequencies.Add(frequency);
            }
        }

        return frequencies;
    }

    public float FindSpectralFlux()
    {
        // Compute the spectral flux
        float spectralFlux = 0f;
        for (int i = 0; i < _spectrum.Length; i++)
        {
            // Compute the change in energy in this bin
            float delta = _spectrum[i] - _prevSpectrum[i];
        
            // Only consider increases in energy
            if (delta > 0)
            {
                spectralFlux += delta;
            }
        }

        // Update the previous spectrum
        _prevSpectrum = new List<float>(_spectrum);

        // return the spectral flux value
        return spectralFlux;
    }

    private IEnumerator FindFrequenciesFromFFTCoroutine(FFTWindow windowType)
    {
        while (true)
        {
            OnlyFFT(windowType);
            FrequencyData?.Invoke(FindFrequenciesFromFFT());
            SpectralFluxData?.Invoke(FindSpectralFlux());
            SpectrumData?.Invoke(_spectrum);

            //x times per second
            yield return new WaitForSeconds(0.01f);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class AudioProcessor : MonoBehaviour
{
    private const int SampleRate = 44100;
    private const int Bins = 8192; // Size of FFT must be power of 2
    private float[] _spectrum = new float[Bins]; 
    private float _frequencyStep;

    // For the spectrum data from the previous frame
    private List<float> _prevSpectrum = Enumerable.Repeat(0f, Bins).ToList();
    
    public Action<List<float>> FrequencyData;
    public Action<float> SpectralFluxData;
    public Action<float[]> SpectrumData;

    private void Start()
    {
        StartCoroutine(ProcessAudio(FFTWindow.BlackmanHarris));
        
        // Step size for each frequency bin (delta Hz per Bins[i])
        _frequencyStep = SampleRate / 2f / _spectrum.Length;
    }

    private void OnlyFFT(FFTWindow windowType)
    {
        AudioListener.GetSpectrumData(_spectrum, 0, windowType);
    }

    public List<float> PruneLowEnergyFrequencies()
    {
        List<float> frequencies = new List<float>();
        for (int i = 0; i < _spectrum.Length; i++)
        {
            if (_spectrum[i] > 0.01f) // Under 0.01f is noise
            {
                float frequency = i * _frequencyStep;
                frequencies.Add(frequency);
            }
        }
        return frequencies;
    }

    private float FindSpectralFlux(out float totalSpectralFlux)
    {
        // Frequency threshold in hz
        float frequencyThreshold = 300f;

        float spectralFlux = 0f;
        totalSpectralFlux = 0f;

        for (int i = 0; i < _spectrum.Length; i++)
        {
            float frequency = i * _frequencyStep;
            float delta = _spectrum[i] - _prevSpectrum[i];

            if (delta > 0)
            {
                totalSpectralFlux += delta; // Total spectral flux without threshold
                if(frequency < frequencyThreshold)
                {
                    spectralFlux += delta; // Spectral flux under frequency threshold
                }
            }
        }

        _prevSpectrum = new List<float>(_spectrum);

        return spectralFlux;
    }


    private IEnumerator ProcessAudio(FFTWindow windowType)
    {
        while (true)
        {
            OnlyFFT(windowType);
            FrequencyData?.Invoke(PruneLowEnergyFrequencies());
            SpectralFluxData?.Invoke(FindSpectralFlux(out _));
            SpectrumData?.Invoke(_spectrum);

            FindSpectralFlux(out AudioManager.Instance.spectralFluxOfEntireTrack);
            
            //process rate
            yield return new WaitForSeconds(0.01667f );
        }
    }
}

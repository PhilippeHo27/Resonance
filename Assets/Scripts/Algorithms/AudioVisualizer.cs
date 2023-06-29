using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualizer : MonoBehaviour
{
    public enum ShapeOfVisuals
    {
        Line, Square, SquareTwo, SquareThree
    }
    
    [Serializable]
    public class TypeOfVisuals
    {
        public string name;
        public bool isActive;
        public ShapeOfVisuals ShapeOfVisual;
    }
    
    public GameObject sampleCubePrefab;
    static readonly int NumberOfGameObjects = 1024;
    private readonly GameObject[] _sampleCubes = new GameObject[NumberOfGameObjects];
    
    [Tooltip("Set the max height of the bars")] 
    public float maxHeight = 0.90f;
    
    [Range(0.01f, 0.09f)] 
    public float spacing;
    
    private MeshRenderer[] _meshRenderers;
    public TypeOfVisuals[] visuals;

    private Dictionary<ShapeOfVisuals, Action> _visualizerActions;
    
    private void Start()
    {
        _meshRenderers = new MeshRenderer[_sampleCubes.Length];

        _visualizerActions = new Dictionary<ShapeOfVisuals, Action>
        {
            { ShapeOfVisuals.Line, InstantiateLine },
            { ShapeOfVisuals.Square, InstantiateSquare },
            { ShapeOfVisuals.SquareTwo, InstantiateSquareTwo }
        };


        foreach (var type in visuals)
        {
            if (type.isActive)
                VisualSorter(type.ShapeOfVisual);
        }
    }
    
    private void OnEnable()
    {
        SingletonDumpster.Instance.audioProcessor.SpectrumData += DisplayVisualizer;
    }

    private void VisualSorter(ShapeOfVisuals shape)
    {
        if (_visualizerActions.TryGetValue(shape, out var action))
        {
            action.Invoke();
        }
    }
    
    private void DisplayVisualizer(float[] samples)
    {
        int groupSize = samples.Length / NumberOfGameObjects / 2; // allegedly no impact at all on performance because of JIT compiler... we shall see
        float[] avgSamples = new float[NumberOfGameObjects];

        // Calculate average for each group
        for (int i = 0; i < NumberOfGameObjects; i++)
        {
            float sum = 0;
            for (int j = 0; j < groupSize; j++)
            {
                sum += samples[i * groupSize + j];
            }
            avgSamples[i] = Mathf.Min(maxHeight,sum / groupSize);
        }
        
        for (int i = 0; i < _sampleCubes.Length; i++)
        {
            if (_sampleCubes[i] != null)
            {
                _sampleCubes[i].transform.localScale = new Vector3(0.1f, (avgSamples[i] * 1000) + 0.1f, 0.1f);
                _meshRenderers[i].material.color = SingletonDumpster.Instance.coloring;
            }
        }
    }

    #region Visualizer's Look

    // private void InstantiateLine()
    // {
    //     float cubeSpacing = sampleCubePrefab.transform.localScale.x / 2 + spacing;;
    //
    //     for (int i = 0; i < _sampleCubes.Length; i++)
    //     {
    //         GameObject cube = Instantiate(sampleCubePrefab);
    //         cube.transform.position = new Vector3(i * cubeSpacing, transform.position.y, transform.position.z);
    //         cube.transform.parent = transform;
    //         cube.name = "SampleCube" + i;
    //         _sampleCubes[i] = cube;
    //         _meshRenderers[i] = _sampleCubes[i].GetComponent<MeshRenderer>();
    //     }
    // }
    
    private void InstantiateLine()
    {
        float cubeSpacing = sampleCubePrefab.transform.localScale.x / 2 + spacing;

        // Frequency range for each cube assuming 1024 cubes from 8192 bins FFT with a sample rate of 44100 Hz
        float cubeFreqRange = (44100f / 8192f) * (8192f / 1024f / 2); 

        for (int i = 0; i < _sampleCubes.Length; i++)
        {
            GameObject cube = Instantiate(sampleCubePrefab);
            cube.transform.position = new Vector3(i * cubeSpacing, transform.position.y, transform.position.z);
            cube.transform.parent = transform;
            float cubeFreqStart = i * cubeFreqRange; // Starting frequency of this cube's range
            float cubeFreqEnd = (i+1) * cubeFreqRange; // Ending frequency of this cube's range
            cube.name = $"SampleCube{i} ({cubeFreqStart}Hz - {cubeFreqEnd}Hz)";
            _sampleCubes[i] = cube;
            _meshRenderers[i] = _sampleCubes[i].GetComponent<MeshRenderer>();
        }
    }

    
    private void InstantiateSquare()
    {
        const int size = 32; // The size of the square root of the number of cubes
        float spacing = 0.2f; // Space between each cube
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                GameObject cube = Instantiate(sampleCubePrefab);
                cube.transform.position = new Vector3(i - size / 2, 0, j - size / 2) * spacing;
                cube.transform.parent = transform;
                cube.name = $"SampleCube{i * size + j}";
                _sampleCubes[i * size + j] = cube;
                _meshRenderers[i * size + j] = _sampleCubes[i*size + j].GetComponent<MeshRenderer>();
            }
        }
    }

    private void InstantiateSquareTwo()
    {
        int totalCubes = 0; // Total number of cubes instantiated

        for (int layer = 0; totalCubes < NumberOfGameObjects; layer++)
        {
            for (int i = -layer; i <= layer && totalCubes < NumberOfGameObjects; i++)
            {
                for (int j = -layer; j <= layer && totalCubes < NumberOfGameObjects; j++)
                {
                    // Only create cubes on the edge of the layer
                    if (i > -layer && i < layer && j > -layer && j < layer)
                        continue;

                    // Instantiate the cube and set its properties
                    GameObject cube = Instantiate(sampleCubePrefab);
                    cube.transform.position = new Vector3(i, 0, j) * spacing;
                    cube.transform.parent = transform;
                    cube.name = $"SampleCube{totalCubes}";

                    // Add the cube and its MeshRenderer to the corresponding arrays
                    _sampleCubes[totalCubes] = cube;
                    _meshRenderers[totalCubes] = cube.GetComponent<MeshRenderer>();
                    totalCubes++;
                }
            }
        }
    }

    #endregion
    
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualizer : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject sampleCubePrefab;
    static readonly int NumberOfGameObjects = 1024;
    private readonly GameObject[] _sampleCubes = new GameObject[NumberOfGameObjects];

    public float tweakme;
    [Range(0.01f, 0.09f)] public float spacing;
    
    private MeshRenderer[] _meshRenderers;

    public TypeOfVisuals[] Visuals;

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
    
    private Dictionary<ShapeOfVisuals, Action> visualizerActions;
    
    private void Start()
    {
        _meshRenderers = new MeshRenderer[_sampleCubes.Length];

        visualizerActions = new Dictionary<ShapeOfVisuals, Action>
        {
            { ShapeOfVisuals.Line, LineVisualizer },
            { ShapeOfVisuals.Square, SquareVisualizer },
            { ShapeOfVisuals.SquareTwo, SquareVisualizer2 }
        };


        foreach (var type in Visuals)
        {
            if (type.isActive)
                VisualSorter(type.ShapeOfVisual);
        }
    }

    private void VisualSorter(ShapeOfVisuals shape)
    {
        if (visualizerActions.TryGetValue(shape, out var action))
        {
            action.Invoke();
        }
    }

    private void LineVisualizer()
    {
        float cubeSpacing = 0.15f;
        cubeSpacing = sampleCubePrefab.transform.localScale.x / 2 + spacing;
    
        for (int i = 0; i < _sampleCubes.Length; i++)
        {
            GameObject cube = Instantiate(sampleCubePrefab);
            cube.transform.position = new Vector3(i * cubeSpacing, transform.position.y, transform.position.z);
            cube.transform.parent = transform;
            cube.name = "SampleCube" + i;
            _sampleCubes[i] = cube;
            _meshRenderers[i] = _sampleCubes[i].GetComponent<MeshRenderer>();
        }
    }
    
    private void SquareVisualizer()
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

    private void SquareVisualizer2()
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



    private void OnEnable()
    {
        SingleTonDumpsterForNow.Instance.audioProcessor.SpectrumData += Visualizer;
    }

    private void OnDisable()
    {
        //SingleTonDumpsterForNow.Instance.audioProcessor.SpectrumData -= Visualizer;
    }

    private void Visualizer(float[] samples)
    {
        int groupSize = samples.Length / NumberOfGameObjects; // allegedly no impact at all on performance because of JIT compiler... we shall see
        float[] avgSamples = new float[NumberOfGameObjects];
    
        // Calculate average for each group
        for (int i = 0; i < NumberOfGameObjects; i++)
        {
            float sum = 0;
            for (int j = 0; j < groupSize; j++)
            {
                sum += samples[i * groupSize + j];
            }
            avgSamples[i] = Mathf.Min(tweakme,sum / groupSize);
        }
        
        for (int i = 0; i < _sampleCubes.Length; i++)
        {
            if (_sampleCubes[i] != null)
            {
                _sampleCubes[i].transform.localScale = new Vector3(0.1f, (avgSamples[i] * 1000) + 0.1f, 0.1f);
                _meshRenderers[i].material.color = SingleTonDumpsterForNow.Instance.coloring;
            }
        }
    }
}

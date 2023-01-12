using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public enum DrawMode
    {
        NOISE_MAP,
        COLOR_MODE,
        MESH,
    }

    [System.Serializable] public struct TerrainType
    {
        public string Name;
        [Range(0.0f, 1.0f)] public float Heigth;
        public Color Color;
    }

    [SerializeField, Min(0)] private int _seed = 0;
    [SerializeField] private bool _useRandSeed = false;

    [SerializeField, Min(1)] private int _mapWidth = 100;
    [SerializeField, Min(1)] private int _mapHeight = 100;
    [SerializeField, Min(0.0f)] private float _noiseScale = 20.0f;
    
    [SerializeField, Range(1, 10)] private int _octaves = 3;
    [SerializeField, Range(0.0f, 1.0f)] private float _persistance = 0.5f;
    [SerializeField, Min(1.0f)] private float _lacunarity = 2;

    [SerializeField] private Vector2 _offset = Vector2.zero;

    [SerializeField, Min(1.0f)] private float _meshHeightMultiplier = 10;
    [SerializeField] private AnimationCurve _meshHeightCurve = null;

    [SerializeField] private TerrainType[] _regions = null;
    [SerializeField] private DrawMode _drawMode = DrawMode.NOISE_MAP;

    [SerializeField] private bool _autoUpdate;
    public bool AutoUpdate
    {
        get { return _autoUpdate; }
    }

    private void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        int currentSeed = (_useRandSeed) ? Random.Range(0, int.MaxValue) : _seed;

        float[,] noiseMap = Noise.GenerateNoiseMap(_mapWidth, _mapHeight, currentSeed, _noiseScale, _octaves, _persistance, _lacunarity, _offset);

        Color[] colorMap = new Color[_mapWidth * _mapHeight];

        for (int x = 0; x < _mapWidth; ++x)
        {
            for (int y = 0; y < _mapHeight; ++y)
            {
                float currentHeight = noiseMap[x, y];

                for (int i = 0; i < _regions.Length; ++i)
                {
                    if (currentHeight <= _regions[i].Heigth)
                    {
                        colorMap[(y * _mapWidth) + x] = _regions[i].Color;
                        break;
                    }
                }
            }
        }

        MapDisplay display = FindObjectOfType<MapDisplay>();

        switch (_drawMode)
        {
            case DrawMode.NOISE_MAP:
            {
                display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));
                break;
            }

            case DrawMode.COLOR_MODE:
            {
                display.DrawTexture(TextureGenerator.TextureFromColorMap(colorMap, _mapWidth, _mapHeight));
                break;
            }

            case DrawMode.MESH:
            {
                display.DrawMesh(MeshGenerator.GenerateTerrainMesh(noiseMap, _meshHeightMultiplier, _meshHeightCurve), TextureGenerator.TextureFromColorMap(colorMap, _mapWidth, _mapHeight));
                break;
            }
        }
    }
}

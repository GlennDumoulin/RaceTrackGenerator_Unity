using PathCreation;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PathCreator))]
public class TrackGenerator : MonoBehaviour
{
    public struct TrackPoint
    {
        public Vector3 Position;
        public Vector3 Normal;

        public TrackPoint(Vector3 position, Vector3 normal)
        {
            Position = position;
            Normal = normal;
        }
    }

    [SerializeField, Min(0)] private int _seed = 0;
    [SerializeField] private bool _useRandSeed = false;

    [SerializeField, Min(1)] private int _mapWidth = 100;
    [SerializeField, Min(1)] private int _mapHeight = 100;

    [SerializeField, Range(2, 20)] private int _nrOfTrackPoints = 8;
    [SerializeField] private bool _isClosed = false;

    [SerializeField] private MeshCollider _meshCollider;

    [SerializeField] private bool _autoUpdate;
    public bool AutoUpdate
    {
        get { return _autoUpdate; }
    }

    private void Start()
    {
        GenerateTrack();
    }

    public void GenerateTrack()
    {
        int currentSeed = (_useRandSeed) ? Random.Range(0, int.MaxValue) : _seed;

        TrackPoint[] trackPoints = RandomWalk.GenerateRandomTrackPoints(_mapWidth, _mapHeight, currentSeed, _nrOfTrackPoints, _meshCollider);

        BezierPath bezierPath = new BezierPath(trackPoints.Select(t => t.Position), trackPoints.Select(t => t.Normal), _isClosed, PathSpace.xyz);
        GetComponent<PathCreator>().bezierPath = bezierPath;
    }
}

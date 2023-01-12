using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomWalk
{
    public static TrackGenerator.TrackPoint[] GenerateRandomTrackPoints(int mapWidth, int mapHeight, int seed, int nrOfTrackPoints, MeshCollider meshCollider)
    {
        TrackGenerator.TrackPoint[] trackPoints = new TrackGenerator.TrackPoint[nrOfTrackPoints];

        System.Random prng = new System.Random(seed);

        for (int i = 0; i < nrOfTrackPoints; ++i)
        {
            Vector3 point = new Vector3();

            Ray ray = new Ray(point, Vector3.down);
            RaycastHit hitInfo;
            do
            {
                point.x = (float)(prng.Next() % mapWidth) - mapWidth / 2.0f;
                point.y = 200.0f;
                point.z = (float)(prng.Next() % mapHeight) - mapHeight / 2.0f;

                ray.origin = point;
            }
            while (!meshCollider.Raycast(ray, out hitInfo, 500.0f));

            trackPoints[i] = new TrackGenerator.TrackPoint(hitInfo.point, hitInfo.normal);
        }

        return trackPoints;
    }
}

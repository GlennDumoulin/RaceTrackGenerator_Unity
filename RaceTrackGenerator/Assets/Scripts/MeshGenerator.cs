using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MeshGenerator
{
    public static MeshData GenerateTerrainMesh(float[,] heightMap, float heightMultiplier, AnimationCurve heightCurve)
    {
        int width = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);

        float topLeftX = (width - 1) / -2.0f;
        float topLeftZ = (height - 1) / 2.0f;

        MeshData meshData = new MeshData(width, height);
        int vertexIdx = 0;

        for (int x = 0; x < width; ++x)
        {
            for (int y = 0; y < height; ++y)
            {
                meshData.vertices[vertexIdx] = new Vector3(topLeftX + x, heightCurve.Evaluate(heightMap[x, y]) * heightMultiplier, topLeftZ - y);
                meshData.uvs[vertexIdx] = new Vector2((float)x / width, (float)y / height);

                if (x < width - 1 && y < height - 1)
                {
                    meshData.AddTriangle(vertexIdx, vertexIdx + width, vertexIdx + width + 1);
                    meshData.AddTriangle(vertexIdx, vertexIdx + width + 1, vertexIdx + 1);
                }

                ++vertexIdx;
            }
        }

        return meshData;
    }
}

public class MeshData
{
    public Vector3[] vertices;
    public Vector2[] uvs;
    public int[] triangles;

    private int _triangleIdx = 0;

    public MeshData(int meshWidth, int meshHeight)
    {
        vertices = new Vector3[meshWidth * meshHeight];
        uvs = new Vector2[meshWidth * meshHeight];
        triangles = new int[((meshWidth - 1) * (meshHeight - 1)) * 6];
    }

    public void AddTriangle(int a, int b, int c)
    {
        triangles[_triangleIdx] = a;
        triangles[_triangleIdx + 1] = b;
        triangles[_triangleIdx + 2] = c;

        _triangleIdx += 3;
    }

    public Mesh CreateMesh()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.triangles = triangles;
        
        mesh.RecalculateNormals();

        return mesh;
    }
}

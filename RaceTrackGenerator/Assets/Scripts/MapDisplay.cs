using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapDisplay : MonoBehaviour
{
    [SerializeField] private GameObject _map;
    [SerializeField] private Renderer _textureRenderer;

    [SerializeField] private GameObject _mesh;
    [SerializeField] private MeshFilter _meshFilter;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private MeshCollider _meshCollider;

    public void DrawTexture(Texture2D texture)
    {
        _mesh.SetActive(false);
        _map.SetActive(true);

        _textureRenderer.sharedMaterial.mainTexture = texture;
        _textureRenderer.transform.localScale = new Vector3(texture.width, 1, texture.height);
    }

    public void DrawMesh(MeshData meshData, Texture2D texture)
    {
        _map.SetActive(false);
        _mesh.SetActive(true);

        Mesh mesh = meshData.CreateMesh();

        _meshFilter.sharedMesh = mesh;
        _meshCollider.sharedMesh = mesh;
        _meshRenderer.sharedMaterial.mainTexture = texture;
    }
}

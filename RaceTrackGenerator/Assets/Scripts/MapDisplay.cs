using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapDisplay : MonoBehaviour
{
    [SerializeField] private Renderer _textureRenderer;

    public void DrawTexture(Texture2D texture)
    {
        _textureRenderer.sharedMaterial.mainTexture = texture;
        _textureRenderer.transform.localScale = new Vector3(texture.width, 1, texture.height);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float speed;
    public Renderer meshRenderer;

    private void Update()
    {
        Vector2 offset = meshRenderer.material.mainTextureOffset;
        offset = offset + new Vector2(0, (speed) * Time.deltaTime);
        meshRenderer.material.mainTextureOffset = offset;
    }
}

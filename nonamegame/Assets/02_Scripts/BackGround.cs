using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    private float targetOffset;
    private new Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        CreateBackGround();
    }

    void CreateBackGround()  // 무한 배경
    {
        targetOffset += Time.deltaTime * scrollSpeed;
        renderer.material.mainTextureOffset = new Vector2(targetOffset, 0);
    }   // CreateBackGround()
}

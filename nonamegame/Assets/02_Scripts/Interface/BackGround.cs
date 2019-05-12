using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    /*
     무한 배경 관련 스크립트
     - 무한 배경 함수(오프셋 이용)
     */

    private float scrollSpeed = 0.2f;   // 배경 이동 속도
    private float targetOffset; // 오프셋 지정
    private new Renderer renderer;
    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }   // Start()

    private void Update()
    {
        CreateBackGround();
    }   // Update()

    void CreateBackGround()  // 무한 배경
    {
        targetOffset += Time.deltaTime * scrollSpeed;
        renderer.material.mainTextureOffset = new Vector2(targetOffset, 0);
    }   // CreateBackGround()

}   // BackGround Class

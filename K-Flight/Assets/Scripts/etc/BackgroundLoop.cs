using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour // 백그라운드 반복
{
    private float height;
    private void Awake()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        height = backgroundCollider.size.y;
    }
    void Update()
    {
        // 배경이 설정된 범위를 벗어나면 위치 재설정
        if (transform.position.y <= -height)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        Vector2 offset = new Vector2(0, height * 2f);
        transform.position = (Vector2)transform.position + offset;
    }
}

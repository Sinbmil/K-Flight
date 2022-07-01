using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour // 이동이 가능한 모든 오브젝트에게 할당
{
    [SerializeField]
    private float moveSpeed = 0.0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    // 이동 방향을 설정
    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}

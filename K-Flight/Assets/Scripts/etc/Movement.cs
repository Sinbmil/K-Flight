using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour // �̵��� ������ ��� ������Ʈ���� �Ҵ�
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

    // �̵� ������ ����
    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}

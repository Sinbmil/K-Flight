using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoCollision : MonoBehaviour // ���׿� �浹
{
    [SerializeField]
    private int damage = 1; // ���׿� ���ݷ�
    [SerializeField]
    private GameObject explosionPrefab; // ���� ȿ��

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���׿��� �ε��� ������Ʈ�� �±װ� player���
        if(collision.CompareTag("Player"))
        {
            // �÷��̾� HP ����
            collision.GetComponent<PlayerHP>().TakeDamage(damage);
            // ���� �̺�Ʈ ����
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            // ���׿� ���
            Destroy(gameObject);
        }
    }
}

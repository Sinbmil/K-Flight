using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire : MonoBehaviour // ���� ���� ����
{
    [SerializeField]
    private int damage = 1;             // ���� ���� ������
    [SerializeField]
    private GameObject explosionPrefab; // ���� ȿ��

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���������� �ε��� ������Ʈ�� Player���
        if(collision.CompareTag("Player"))
        {
            // �÷��̾� ü�� ����
            collision.GetComponent<PlayerHP>().TakeDamage(damage);
            // �� ������Ʈ ����
            Destroy(gameObject);
        }
    }
    public void OnDIe()
    {
        // ���� ȿ�� ����
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        // ���� �߻�ü ����
        Destroy(gameObject);
    }
}

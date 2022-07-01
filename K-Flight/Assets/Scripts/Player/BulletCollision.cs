using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour // �Ѿ� �浹
{
    [SerializeField]
    private int damage = 1; // �Ѿ� ���ݷ�

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �Ѿ˿� �ε��� ������Ʈ�� �±װ� Enemy�̸�
        if(collision.CompareTag("Enemy"))
        {
            // �ε��� �� ���
            collision.GetComponent<EnemyHP>().TakeDamage(damage);
            // �� �Ѿ� ����
            Destroy(gameObject);
        }
        // �Ѿ˿� �ε��� ������Ʈ�� �±װ� Boss�̸�
        else if (collision.CompareTag("Boss"))
        {
            // �ε��� �� ���
            collision.GetComponent<BossHP>().TakeDamage(damage);
            // �� �Ѿ� ����
            Destroy(gameObject);
        }
    }
}

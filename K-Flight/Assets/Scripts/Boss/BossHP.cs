using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour // ���� HP
{
    [SerializeField]
    private float maxHP = 500;  // �ִ� ü��
    private float currentHP;    // ���� ü��
    private SpriteRenderer spriteRenderer;
    private Boss boss;
    private bool isdie = false; // ���� �Ǵ� ����
    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;

    private void Awake()
    {
        currentHP = maxHP; // ���� ü���� �ִ� ü�°� ���� ����
        spriteRenderer = GetComponent<SpriteRenderer>();
        boss = GetComponent<Boss>();
    }

    public void TakeDamage(int damage)
    {
        if (isdie == true) return;
        // ���� ü�¿��� ������ ��ŭ �����ϱ�
        currentHP -= damage;

        // ü���� 0���ϸ� ���
        if (currentHP <= 0)
        {
            isdie = true;
            boss.OnDie();
        }
    }
}

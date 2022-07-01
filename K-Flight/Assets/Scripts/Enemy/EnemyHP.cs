using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 5; // �ִ� ü��
    private float currentHP; // ���� ü��
    private EnemyCollision enemy;
    private SpriteRenderer spriteRenderer;

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;

    private void Awake()
    {
        currentHP = maxHP;
        enemy = GetComponent<EnemyCollision>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;

        // ü���� 0���ϸ� ���
        if (currentHP <= 0)
        {
            enemy.OnDie();
        }
    }
}

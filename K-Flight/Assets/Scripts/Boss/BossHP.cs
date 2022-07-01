using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour // 보스 HP
{
    [SerializeField]
    private float maxHP = 500;  // 최대 체력
    private float currentHP;    // 현재 체력
    private SpriteRenderer spriteRenderer;
    private Boss boss;
    private bool isdie = false; // 죽음 판단 변수
    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;

    private void Awake()
    {
        currentHP = maxHP; // 현재 체력을 최대 체력과 같게 설정
        spriteRenderer = GetComponent<SpriteRenderer>();
        boss = GetComponent<Boss>();
    }

    public void TakeDamage(int damage)
    {
        if (isdie == true) return;
        // 현재 체력에서 데미지 만큼 감소하기
        currentHP -= damage;

        // 체력이 0이하면 사망
        if (currentHP <= 0)
        {
            isdie = true;
            boss.OnDie();
        }
    }
}

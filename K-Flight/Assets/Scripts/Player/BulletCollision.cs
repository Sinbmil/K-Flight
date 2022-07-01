using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour // 총알 충돌
{
    [SerializeField]
    private int damage = 1; // 총알 공격력

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 총알에 부딪힌 오브젝트의 태그가 Enemy이면
        if(collision.CompareTag("Enemy"))
        {
            // 부딪힌 적 사망
            collision.GetComponent<EnemyHP>().TakeDamage(damage);
            // 내 총알 삭제
            Destroy(gameObject);
        }
        // 총알에 부딪힌 오브젝트의 태그가 Boss이면
        else if (collision.CompareTag("Boss"))
        {
            // 부딪힌 적 사망
            collision.GetComponent<BossHP>().TakeDamage(damage);
            // 내 총알 삭제
            Destroy(gameObject);
        }
    }
}

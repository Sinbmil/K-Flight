using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoCollision : MonoBehaviour // 메테오 충돌
{
    [SerializeField]
    private int damage = 1; // 메테오 공격력
    [SerializeField]
    private GameObject explosionPrefab; // 폭발 효과

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 메테오에 부딪힌 오브젝트의 태그가 player라면
        if(collision.CompareTag("Player"))
        {
            // 플레이어 HP 감소
            collision.GetComponent<PlayerHP>().TakeDamage(damage);
            // 폭발 이벤트 생성
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            // 메테오 사망
            Destroy(gameObject);
        }
    }
}

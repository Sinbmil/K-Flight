using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire : MonoBehaviour // 보스 공격 설정
{
    [SerializeField]
    private int damage = 1;             // 보스 공격 데미지
    [SerializeField]
    private GameObject explosionPrefab; // 폭발 효과

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 보스공격이 부딪힌 오브젝트가 Player라면
        if(collision.CompareTag("Player"))
        {
            // 플레이어 체력 감소
            collision.GetComponent<PlayerHP>().TakeDamage(damage);
            // 내 오브젝트 삭제
            Destroy(gameObject);
        }
    }
    public void OnDIe()
    {
        // 폭발 효과 생성
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        // 보스 발사체 삭제
        Destroy(gameObject);
    }
}

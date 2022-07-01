using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField]
    private int damage = 1; // 적 공격력
    [SerializeField]
    private int point = 300; // 적 처치시 점수 획득
    [SerializeField]
    private GameObject explosionPrefab; // 폭발 효과
    [SerializeField]
    private GameObject[] itemPrefabs; // 적을 죽였을 때 획득 아이템
    private PlayerController playerController;

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 적에게 부딪힌 오브젝트의 태그가 Player라면
        if(collision.CompareTag("Player"))
        {
            // 플레이어 HP 감소
            collision.GetComponent<PlayerHP>().TakeDamage(damage);
            // 폭발 이벤트 생성
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            // 적 사망
            OnDie();
        }
    }

    public void OnDie()
    {
        // 플레이어 점수 point를 계속 더해서 증가
        playerController.Score += point;
        // 폭발 이벤트 생성
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        // 일정 확률로 아이템 생성
        SpawnItem();
        // 적 오브젝트 삭제
        Destroy(gameObject);
    }

    private void SpawnItem()
    {
        // 총알강화(5%), 코인(15%), 보석(10%), 다이아(5%)
        int spawnItem = Random.Range(0, 100);
        if(spawnItem <5)
        {
            Instantiate(itemPrefabs[0], transform.position, Quaternion.identity);
        }
        else if(spawnItem<20)
        {
            Instantiate(itemPrefabs[1], transform.position, Quaternion.identity);
        }
        else if(spawnItem<30)
        {
            Instantiate(itemPrefabs[2], transform.position, Quaternion.identity);
        }
        else if(spawnItem< 35)
        {
            Instantiate(itemPrefabs[3], transform.position, Quaternion.identity);
        }
    }
}

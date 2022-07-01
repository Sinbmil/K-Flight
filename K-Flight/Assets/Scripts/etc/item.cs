using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { BulletUp = 0, Coin=1, Gem=2, Dia=3, }
public class item : MonoBehaviour // 아이템
{
    [SerializeField]
    private ItemType itemType;
    private int coinpoint = 100;                // 코인 포인트
    private int gempoint = 300;                 // 보석 포인트
    private int diapoint = 500;                 // 다이아 포인트
    private PlayerController playerController;
    [SerializeField]
    private GameObject explosionPrefab;         // 폭발 효과

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 적에게 부딪힌 오브젝트의 태그가 Player라면
        if (collision.CompareTag("Player"))
        {
            // 아이템 획득시 사용
            Use(collision.gameObject);
            // 폭발 이벤트 생성
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            // 아이템 오브젝트 삭제
            Destroy(gameObject);
        }
    }

    public void Use(GameObject player)
    {
        switch(itemType)
        {
            case ItemType.BulletUp: // 총알 강화 아이템일때 총알 레벨 증가
                player.GetComponent<Bullet>().AttackLevel++;
                break;
            case ItemType.Coin:     // 코인 아이템일때 코인 포인트만큼 증가
                player.GetComponent<PlayerController>();
                playerController.Score += coinpoint;
                break;
            case ItemType.Gem:      // 보석 아이템일때 보석 포인트만큼 증가
                player.GetComponent<PlayerController>();
                playerController.Score += gempoint;
                break;
            case ItemType.Dia:      // 다이아 아이템일때 다이아 포인트만큼 증가
                player.GetComponent<PlayerController>();
                playerController.Score += diapoint;
                break;
        }
    }
}

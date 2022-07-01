using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour // 플레이어 HP
{
    [SerializeField]
    private int hp = 1; // 플레이어 체력
    private SpriteRenderer spriteRenderer;
    private PlayerController playerController;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerController = GetComponent<PlayerController>();
    }

    public void TakeDamage(int damage) // 데미지
    {
       hp -= damage;
        
       if (hp <= 0) // 체력이 0 이하 되면 OnDie 메소드 실행
        {
            gameObject.SetActive(false);
            playerController.OnDie();
        }
    }
}

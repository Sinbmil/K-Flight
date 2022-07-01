using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour // �÷��̾� HP
{
    [SerializeField]
    private int hp = 1; // �÷��̾� ü��
    private SpriteRenderer spriteRenderer;
    private PlayerController playerController;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerController = GetComponent<PlayerController>();
    }

    public void TakeDamage(int damage) // ������
    {
       hp -= damage;
        
       if (hp <= 0) // ü���� 0 ���� �Ǹ� OnDie �޼ҵ� ����
        {
            gameObject.SetActive(false);
            playerController.OnDie();
        }
    }
}

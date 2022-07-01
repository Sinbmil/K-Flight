using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { BulletUp = 0, Coin=1, Gem=2, Dia=3, }
public class item : MonoBehaviour // ������
{
    [SerializeField]
    private ItemType itemType;
    private int coinpoint = 100;                // ���� ����Ʈ
    private int gempoint = 300;                 // ���� ����Ʈ
    private int diapoint = 500;                 // ���̾� ����Ʈ
    private PlayerController playerController;
    [SerializeField]
    private GameObject explosionPrefab;         // ���� ȿ��

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ������ �ε��� ������Ʈ�� �±װ� Player���
        if (collision.CompareTag("Player"))
        {
            // ������ ȹ��� ���
            Use(collision.gameObject);
            // ���� �̺�Ʈ ����
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            // ������ ������Ʈ ����
            Destroy(gameObject);
        }
    }

    public void Use(GameObject player)
    {
        switch(itemType)
        {
            case ItemType.BulletUp: // �Ѿ� ��ȭ �������϶� �Ѿ� ���� ����
                player.GetComponent<Bullet>().AttackLevel++;
                break;
            case ItemType.Coin:     // ���� �������϶� ���� ����Ʈ��ŭ ����
                player.GetComponent<PlayerController>();
                playerController.Score += coinpoint;
                break;
            case ItemType.Gem:      // ���� �������϶� ���� ����Ʈ��ŭ ����
                player.GetComponent<PlayerController>();
                playerController.Score += gempoint;
                break;
            case ItemType.Dia:      // ���̾� �������϶� ���̾� ����Ʈ��ŭ ����
                player.GetComponent<PlayerController>();
                playerController.Score += diapoint;
                break;
        }
    }
}

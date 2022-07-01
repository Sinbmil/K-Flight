using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField]
    private int damage = 1; // �� ���ݷ�
    [SerializeField]
    private int point = 300; // �� óġ�� ���� ȹ��
    [SerializeField]
    private GameObject explosionPrefab; // ���� ȿ��
    [SerializeField]
    private GameObject[] itemPrefabs; // ���� �׿��� �� ȹ�� ������
    private PlayerController playerController;

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ������ �ε��� ������Ʈ�� �±װ� Player���
        if(collision.CompareTag("Player"))
        {
            // �÷��̾� HP ����
            collision.GetComponent<PlayerHP>().TakeDamage(damage);
            // ���� �̺�Ʈ ����
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            // �� ���
            OnDie();
        }
    }

    public void OnDie()
    {
        // �÷��̾� ���� point�� ��� ���ؼ� ����
        playerController.Score += point;
        // ���� �̺�Ʈ ����
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        // ���� Ȯ���� ������ ����
        SpawnItem();
        // �� ������Ʈ ����
        Destroy(gameObject);
    }

    private void SpawnItem()
    {
        // �Ѿ˰�ȭ(5%), ����(15%), ����(10%), ���̾�(5%)
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

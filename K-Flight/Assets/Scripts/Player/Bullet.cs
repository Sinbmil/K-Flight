using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour // �Ѿ�
{
    [SerializeField]
    private GameObject bullet;       // ������ �� �����Ǵ� �Ѿ� 

    [SerializeField]
    private float attackRate = 0.1f; // ���� �ӵ�
    [SerializeField]
    private int maxAttackLevel = 5;  // ���� �ִ� ����
    private int attackLevel = 1;     // ���� ����
    private AudioSource audioSource;

    public int AttackLevel
    {
        set => attackLevel = Mathf.Clamp(value, 1, maxAttackLevel);
        get => attackLevel;
    }
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void StartFiring()        // ���� ����
    {
        StartCoroutine("TryAttack");
    }

    public void StopFiring()        // ���� ����
    {
        StopCoroutine("TryAttack");
    }

    private IEnumerator TryAttack()
    {
        while (true)
        {
            // ���� ������ ���� �Ѿ� ����
            AttackByLevel();
            // �Ѿ� ���� ���
            audioSource.Play();

            // attackRate �ð���ŭ ���
            yield return new WaitForSeconds(attackRate);
        }
    }

    
    private void AttackByLevel()     // ���� ����
    {
        GameObject cloneProjectile = null;

        switch(attackLevel)
        {
            case 1: // ����1 - �Ѿ� 1��
                Instantiate(bullet, transform.position, Quaternion.identity);
                break;
            case 2: // ����2 - �Ѿ� 2��
                Instantiate(bullet, transform.position + Vector3.left*0.2f, Quaternion.identity);
                Instantiate(bullet, transform.position + Vector3.right*0.2f, Quaternion.identity);
                break;
            case 3: // ����3 - �Ѿ� 3��
                Instantiate(bullet, transform.position + Vector3.left * 0.2f, Quaternion.identity);
                Instantiate(bullet, transform.position, Quaternion.identity);
                Instantiate(bullet, transform.position + Vector3.right * 0.2f, Quaternion.identity);
                break;
            case 4: // ����4 - �糡 �Ѿ� �̼��� �밢�� �������� �߻�
                Instantiate(bullet, transform.position, Quaternion.identity);
                cloneProjectile = Instantiate(bullet, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement>().MoveTo(new Vector3(-0.1f, 1, 0));

                cloneProjectile = Instantiate(bullet, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement>().MoveTo(new Vector3(0.1f, 1, 0));
                break;
            case 5: // ����5 - �糡 �Ѿ� �밢�� �������� �߻�
                Instantiate(bullet, transform.position, Quaternion.identity);
                cloneProjectile = Instantiate(bullet, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement>().MoveTo(new Vector3(-0.2f, 1, 0));

                cloneProjectile = Instantiate(bullet, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement>().MoveTo(new Vector3(0.2f, 1, 0));
                break;
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState { MoveToAppearPoint =0, Phase01, Phase02, Phase03, Phase04 }

public class Boss : MonoBehaviour // ���� ����
{
    [SerializeField]
    private StageLimit stagelimit;                                  // ȭ�� ��谪
    [SerializeField]
    private float bossAppearPoint = 7f;                             // ���� ���� ��ġ ����
    [SerializeField]
    private GameObject explosionPrefab;                             // ���� ȿ��
    [SerializeField]
    private int point = 30000;                                      // ���� óġ�� ����
    private BossState bossState = BossState.MoveToAppearPoint;
    private Movement movement;                                      // �̵� ����
    private BossWeapon bossWeapon;                                  // ���� ����
    private BossHP bossHP;                                          // ���� ü��
    [SerializeField]
    private PlayerController playerController;                      // �÷��̾�
    [SerializeField]
    private string nextSceneName;                                   // ���� �� �̸�

    private void Awake()
    {
        movement = GetComponent<Movement>();
        bossWeapon = GetComponent<BossWeapon>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        bossHP = GetComponent<BossHP>();
    }
   
    public void ChangeState(BossState newState)  // ���� ���� ��ȯ
    {
        StopCoroutine(bossState.ToString());
        bossState = newState;
        StartCoroutine(bossState.ToString());
    }

    private IEnumerator MoveToAppearPoint()     // ���� ���� �ϱ�
    {
        movement.MoveTo(Vector3.down);

        while(true)
        {
            if(transform.position.y <= bossAppearPoint)  // ���� ���� ��ġ ������ �� ũ��
            {
                movement.MoveTo(Vector3.zero);           // ���� �̵� ����
                ChangeState(BossState.Phase01);          // 1�ܰ� ���� ��ȯ
            }
            yield return null;
        }
    }
    private IEnumerator Phase01()                        // 1�ܰ� �⺻���� `
    {
        bossWeapon.StartFiring(AttackType.BasicAttack);  // ���� ����

        while (true)
        {
            // ���� ü���� 75%���ϰ� �Ǹ� ����
            if (bossHP.CurrentHP <= bossHP.MaxHP * 0.75f)
            {
                // �⺻ ���� ����
                bossWeapon.StopFiring(AttackType.BasicAttack);
                // ���� �ܰ� ����
                ChangeState(BossState.Phase02);
            }
            yield return null;
        }
    }

    private IEnumerator Phase02()                        // 2�ܰ� ����(��) `
    {
        bossWeapon.StartFiring(AttackType.CircleFire);   // �� ���� ����

        while(true)
        {
            // ���� ü���� 50%���ϰ� �Ǹ� ����
            if(bossHP.CurrentHP <= bossHP.MaxHP * 0.5f)
            {
                // �� ���� ����
                bossWeapon.StopFiring(AttackType.CircleFire);
                // ���� �ܰ� ����
                ChangeState(BossState.Phase03);
            }
            yield return null;
        }
    }
    
    private IEnumerator Phase03()                        // 3�ܰ� ����(�) `
    {
        // �÷��̾� ��ġ�� �������� �߻�ü ���� ����
        bossWeapon.StartFiring(AttackType.SingleFireToCenterPosition);

        // ó�� �̵� ���� ������
        Vector3 direction = Vector3.right;
        movement.MoveTo(direction);

        while (true)
        {
            // �¿� �̵� �� ���� �� �����ϸ� ������ �ݴ�� ����
            if(transform.position.x <= stagelimit.LimitMin.x ||
                transform.position.x >= stagelimit.LimitMax.x)
            {
                direction *= -1;
                movement.MoveTo(direction);
            }
            // ���� ü���� 25%���ϰ� �Ǹ� ����
            if (bossHP.CurrentHP <= bossHP.MaxHP * 0.25f)
            {
                // � ���� ����
                bossWeapon.StopFiring(AttackType.SingleFireToCenterPosition);
                // ���� �ܰ� ����
                ChangeState(BossState.Phase04);
            }
            yield return null;
        }
    }

    private IEnumerator Phase04()                        // 4�ܰ� ����(�+�Ѿ� �߰�) `
    {
        // �÷��̾� ��ġ�� �������� �߻�ü ���� ����
        bossWeapon.StartFiring(AttackType.TripleAttack);

        // ó�� �̵� ���� ������
        Vector3 direction = Vector3.right;
        movement.MoveTo(direction);

        while (true)
        {
            // �¿� �̵� �� ���� �� �����ϸ� ������ �ݴ�� ����
            if (transform.position.x <= stagelimit.LimitMin.x ||
                transform.position.x >= stagelimit.LimitMax.x)
            {
                direction *= -1;
                movement.MoveTo(direction);
            }
            yield return null;
        }
    }


    public void OnDie()
    {
        // �÷��̾� ���� point�� ��� ���ؼ� ����
        playerController.Score += point;
        // ���� �̺�Ʈ ����
        GameObject clone = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        // ���� �̺�Ʈ �� �� ��ȯ�� ���� ����
        clone.GetComponent<BossExplosion>().Setup(playerController, nextSceneName);
        // ���� ������Ʈ ����
        Destroy(gameObject);
    }
}

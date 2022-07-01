using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState { MoveToAppearPoint =0, Phase01, Phase02, Phase03, Phase04 }

public class Boss : MonoBehaviour // 보스 설정
{
    [SerializeField]
    private StageLimit stagelimit;                                  // 화면 경계값
    [SerializeField]
    private float bossAppearPoint = 7f;                             // 보스 접근 위치 지점
    [SerializeField]
    private GameObject explosionPrefab;                             // 폭발 효과
    [SerializeField]
    private int point = 30000;                                      // 보스 처치시 점수
    private BossState bossState = BossState.MoveToAppearPoint;
    private Movement movement;                                      // 이동 변수
    private BossWeapon bossWeapon;                                  // 보스 무기
    private BossHP bossHP;                                          // 보스 체력
    [SerializeField]
    private PlayerController playerController;                      // 플레이어
    [SerializeField]
    private string nextSceneName;                                   // 다음 씬 이름

    private void Awake()
    {
        movement = GetComponent<Movement>();
        bossWeapon = GetComponent<BossWeapon>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        bossHP = GetComponent<BossHP>();
    }
   
    public void ChangeState(BossState newState)  // 보스 무기 전환
    {
        StopCoroutine(bossState.ToString());
        bossState = newState;
        StartCoroutine(bossState.ToString());
    }

    private IEnumerator MoveToAppearPoint()     // 보스 접근 하기
    {
        movement.MoveTo(Vector3.down);

        while(true)
        {
            if(transform.position.y <= bossAppearPoint)  // 보스 접근 위치 지점이 더 크면
            {
                movement.MoveTo(Vector3.zero);           // 보스 이동 중지
                ChangeState(BossState.Phase01);          // 1단계 공격 전환
            }
            yield return null;
        }
    }
    private IEnumerator Phase01()                        // 1단계 기본공격 `
    {
        bossWeapon.StartFiring(AttackType.BasicAttack);  // 공격 시작

        while (true)
        {
            // 보스 체력이 75%이하가 되면 실행
            if (bossHP.CurrentHP <= bossHP.MaxHP * 0.75f)
            {
                // 기본 공격 중지
                bossWeapon.StopFiring(AttackType.BasicAttack);
                // 공격 단계 증가
                ChangeState(BossState.Phase02);
            }
            yield return null;
        }
    }

    private IEnumerator Phase02()                        // 2단계 공격(원) `
    {
        bossWeapon.StartFiring(AttackType.CircleFire);   // 원 공격 시작

        while(true)
        {
            // 보스 체력이 50%이하가 되면 실행
            if(bossHP.CurrentHP <= bossHP.MaxHP * 0.5f)
            {
                // 원 공격 중지
                bossWeapon.StopFiring(AttackType.CircleFire);
                // 공격 단계 증가
                ChangeState(BossState.Phase03);
            }
            yield return null;
        }
    }
    
    private IEnumerator Phase03()                        // 3단계 공격(곡선) `
    {
        // 플레이어 위치를 기준으로 발사체 공격 시작
        bossWeapon.StartFiring(AttackType.SingleFireToCenterPosition);

        // 처음 이동 방향 오른쪽
        Vector3 direction = Vector3.right;
        movement.MoveTo(direction);

        while (true)
        {
            // 좌우 이동 중 양쪽 끝 도달하면 방향을 반대로 설정
            if(transform.position.x <= stagelimit.LimitMin.x ||
                transform.position.x >= stagelimit.LimitMax.x)
            {
                direction *= -1;
                movement.MoveTo(direction);
            }
            // 보스 체력이 25%이하가 되면 실행
            if (bossHP.CurrentHP <= bossHP.MaxHP * 0.25f)
            {
                // 곡선 공격 중지
                bossWeapon.StopFiring(AttackType.SingleFireToCenterPosition);
                // 공격 단계 증가
                ChangeState(BossState.Phase04);
            }
            yield return null;
        }
    }

    private IEnumerator Phase04()                        // 4단계 공격(곡선+총알 추가) `
    {
        // 플레이어 위치를 기준으로 발사체 공격 시작
        bossWeapon.StartFiring(AttackType.TripleAttack);

        // 처음 이동 방향 오른쪽
        Vector3 direction = Vector3.right;
        movement.MoveTo(direction);

        while (true)
        {
            // 좌우 이동 중 양쪽 끝 도달하면 방향을 반대로 설정
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
        // 플레이어 점수 point를 계속 더해서 증가
        playerController.Score += point;
        // 폭발 이벤트 생성
        GameObject clone = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        // 폭발 이벤트 후 씬 전환을 위한 설정
        clone.GetComponent<BossExplosion>().Setup(playerController, nextSceneName);
        // 보스 오브젝트 삭제
        Destroy(gameObject);
    }
}

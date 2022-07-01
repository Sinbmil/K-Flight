using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour // 플레이어 
{
    [SerializeField]
    private string nextSceneName;                       // 다음 씬 이름
    [SerializeField]
    private StageLimit stagelimit;                      // 화면 경계값
    [SerializeField]
    private KeyCode keyCodeAttack = KeyCode.Space;      // 키 코드 = 스페이스
    [SerializeField]
    private GameObject explosionPrefab;                 // 폭발 효과
    private bool isdie = false;                         // 죽음 판단 변수
    private Movement movement;                          // 이동 변수
    private Bullet bullet;                              // 총알
    private int score;                                  // 점수

    public int Score  // 점수 저장하고 얻어오기
    {
        // score 값이 음수가 되지 않도록
        set => score = Mathf.Max(0, value);
        get => score;
    } 

    private void Awake()
    {
        movement = GetComponent<Movement>();
        bullet = GetComponent<Bullet>();
    }

    private void Update()
    {
        if (isdie == true) return;
        // 방향 키를 눌러 이동 방향 설정
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        movement.MoveTo(new Vector3(x, y, 0));

        // 공격 키를 Down/Up으로 공격 시작/종료
        if (Input.GetKeyDown(keyCodeAttack))
        {
            bullet.StartFiring(); // 총알 발사
        }
        else if (Input.GetKeyUp(keyCodeAttack))
        {
            bullet.StopFiring(); // 총알 발사 정지
        }
    }

    private void LateUpdate() // 플레이어 캐릭터가 화면 바깥으로 못 나가도록 설정
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stagelimit.LimitMin.x, stagelimit.LimitMax.x), 
            Mathf.Clamp(transform.position.y, stagelimit.LimitMin.y, stagelimit.LimitMax.y));
    }

    public void OnDie()
    {
        // 이동 방향 초기화
        movement.MoveTo(Vector3.zero);
        // 폭발 이벤트 생성
        GameObject clone = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        // 적들과 충돌하지 않도록 충돌 박스 삭제
        Destroy(GetComponent<CircleCollider2D>());
        // 사망 시 플레이어 조작을 하지 못하게 하는 변수
        isdie = true;
        OnDieEvent();
    }

    public void OnDieEvent() 
    {
        // 획득한 점수 score 저장
        PlayerPrefs.SetInt("Score", score);
        // 플레이어 사망시 게임 오버 씬으로 이동
        SceneManager.LoadScene(nextSceneName);
    }
}

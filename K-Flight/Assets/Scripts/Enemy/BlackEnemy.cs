using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackEnemy : MonoBehaviour
{
    [SerializeField]
    private StageLimit stagelimit; // 화면 크기 정보
    [SerializeField]
    private GameObject enemy; // 적 생성할 변수 
    [SerializeField]
    private GameObject enemyHPSlider; // 적 체력을 나타내는 Slider UI 
    [SerializeField]
    private Transform canvasTransform; // UI를 표현하는 Canvas 오브젝트의 Transform
    [SerializeField]
    private BGMController bgmController; // 배경음악 설정(보스 등장)
    [SerializeField]
    private GameObject Warningleft; // 보스 등장 왼쪽 텍스트
    [SerializeField]
    private GameObject Warningright; // 보스 등장 오른쪽 텍스트
    [SerializeField]
    private GameObject bossHPSlider; // 보스 체력 나타내는 Slider UI
    [SerializeField]
    private GameObject boss; // 보스 오브젝트
    [SerializeField]
    private float spawnTime; // 생성 주기
    [SerializeField]
    public int maxEnemyCount = 50; // 현재 스테이지의 최대 적 생성 숫자

    private void Awake()
    {
        // 보스 등장 텍스트 비활성화
        Warningleft.SetActive(false);
        Warningright.SetActive(false);
        bossHPSlider.SetActive(false);
        boss.SetActive(false);
        StartCoroutine("SpawnEnemy");
    }

    public IEnumerator SpawnEnemy()
    {
        int currentEnemyCount = 0; // 적 생성 숫자 카운트 변수
        while (true)
        {
            // x위치를 화면의 크기 범위 내에서 랜덤값으로 선택
            float positionX = Random.Range(stagelimit.LimitMin.x, stagelimit.LimitMax.x);
            // 적 캐릭터 생성
            GameObject enemyClone = Instantiate(enemy, new Vector3(positionX, stagelimit.LimitMax.y + 1.0f, 0.0f), Quaternion.identity);
            // 적 체력을 나타내는 Slider UI 설정
            EnemyHPSlider(enemyClone);
            // 적 생성 숫자 증가
            currentEnemyCount++;

            // 적을 최대 숫자까지 생성하면 보스 생성 실행
            if (currentEnemyCount == maxEnemyCount)
            {
                break;
            }
            // spawnTime만큼 대기
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void EnemyHPSlider(GameObject enemy)
    {
        // 적 체력을 나타내는 Slider UI 설정
        GameObject sliderClone = Instantiate(enemyHPSlider);
        sliderClone.transform.SetParent(canvasTransform);
        // 바뀐 크기를 다시 1,1,1로 설정
        sliderClone.transform.localScale = Vector3.one;

        // Slider UI가 쫓아다닐 대상을 본인으로 설정
        sliderClone.GetComponent<SliderPositionAuto>().Setup(enemy.transform);
        // Slider UI에 체력 정보 표시
        sliderClone.GetComponent<EnemyHPViewer>().Setup(enemy.GetComponent<EnemyHP>());
    }
}

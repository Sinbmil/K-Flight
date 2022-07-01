using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteo : MonoBehaviour // 메테오
{
    [SerializeField]
    private StageLimit stagelimit;     // 화면 경계값
    [SerializeField]
    private GameObject meteoline;      // 메테오 라인
    [SerializeField]
    private GameObject meteo;          // 메테오
    [SerializeField]
    private float minSpawnTime = 4.0f; // 최소 생성 주기
    [SerializeField]
    private float maxSpawnTime = 5.0f; // 최대 생성 주기
    [SerializeField]
    public int maxMeteoCount = 10; // 메테오 최대 생성 개수

    private void Awake()
    {
        StartCoroutine("SpawnMeteo");
    }

    private IEnumerator SpawnMeteo()
    {
        int currentMeteoCount = 0; // 메테오 숫자 카운트 변수
        while (true)
        {
            // 메테오 카운트 증가
            currentMeteoCount++;
            // 메테오 최대값 생성시 중지
            if (currentMeteoCount == maxMeteoCount)
            {
                break;
            }
            // x위치는 랜덤값으로 설정
            float positionX = Random.Range(stagelimit.LimitMin.x, stagelimit.LimitMax.x);
            // 메테로 라인 생성
            GameObject meteolineclone = Instantiate(meteoline, new Vector3(positionX, 0, 0), Quaternion.identity);

            // 1초간 대기
            yield return new WaitForSeconds(1.0f);

            // 메테로라인 삭제
            Destroy(meteolineclone);

            // 메테오 생성
            Vector3 meteoPosition = new Vector3(positionX, stagelimit.LimitMax.y + 1.0f, 0);
            Instantiate(meteo, meteoPosition, Quaternion.identity);

            // 대기 시간 설정(minSpawnTime ~ maxSpawnTime)
            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}

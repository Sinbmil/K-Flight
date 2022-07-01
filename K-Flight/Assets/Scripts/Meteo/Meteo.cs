using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteo : MonoBehaviour // ���׿�
{
    [SerializeField]
    private StageLimit stagelimit;     // ȭ�� ��谪
    [SerializeField]
    private GameObject meteoline;      // ���׿� ����
    [SerializeField]
    private GameObject meteo;          // ���׿�
    [SerializeField]
    private float minSpawnTime = 4.0f; // �ּ� ���� �ֱ�
    [SerializeField]
    private float maxSpawnTime = 5.0f; // �ִ� ���� �ֱ�
    [SerializeField]
    public int maxMeteoCount = 10; // ���׿� �ִ� ���� ����

    private void Awake()
    {
        StartCoroutine("SpawnMeteo");
    }

    private IEnumerator SpawnMeteo()
    {
        int currentMeteoCount = 0; // ���׿� ���� ī��Ʈ ����
        while (true)
        {
            // ���׿� ī��Ʈ ����
            currentMeteoCount++;
            // ���׿� �ִ밪 ������ ����
            if (currentMeteoCount == maxMeteoCount)
            {
                break;
            }
            // x��ġ�� ���������� ����
            float positionX = Random.Range(stagelimit.LimitMin.x, stagelimit.LimitMax.x);
            // ���׷� ���� ����
            GameObject meteolineclone = Instantiate(meteoline, new Vector3(positionX, 0, 0), Quaternion.identity);

            // 1�ʰ� ���
            yield return new WaitForSeconds(1.0f);

            // ���׷ζ��� ����
            Destroy(meteolineclone);

            // ���׿� ����
            Vector3 meteoPosition = new Vector3(positionX, stagelimit.LimitMax.y + 1.0f, 0);
            Instantiate(meteo, meteoPosition, Quaternion.identity);

            // ��� �ð� ����(minSpawnTime ~ maxSpawnTime)
            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}

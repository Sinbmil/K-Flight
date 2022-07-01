using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : MonoBehaviour
{
    [SerializeField]
    private StageLimit stagelimit; // ȭ�� ũ�� ����
    [SerializeField]
    private GameObject enemy; // �� ������ ���� 
    [SerializeField]
    private GameObject enemyHPSlider; // �� ü���� ��Ÿ���� Slider UI 
    [SerializeField]
    private Transform canvasTransform; // UI�� ǥ���ϴ� Canvas ������Ʈ�� Transform
    [SerializeField]
    private BGMController bgmController; // ������� ����(���� ����)
    [SerializeField]
    private GameObject Warningleft; // ���� ���� ���� �ؽ�Ʈ
    [SerializeField]
    private GameObject Warningright; // ���� ���� ������ �ؽ�Ʈ
    [SerializeField]
    private GameObject bossHPSlider; // ���� ü�� ��Ÿ���� Slider UI
    [SerializeField]
    private GameObject boss; // ���� ������Ʈ
    [SerializeField]
    private float spawnTime; // ���� �ֱ�
    [SerializeField]
    public int maxEnemyCount = 50; // ���� ���������� �ִ� �� ���� ����

    private void Awake()
    {
        // ���� ���� �ؽ�Ʈ ��Ȱ��ȭ
        Warningleft.SetActive(false);
        Warningright.SetActive(false);
        bossHPSlider.SetActive(false);
        boss.SetActive(false);
        StartCoroutine("SpawnEnemy");
    }

    public IEnumerator SpawnEnemy()
    {
        int currentEnemyCount = 0; // �� ���� ���� ī��Ʈ ����
        while (true)
        {
            // x��ġ�� ȭ���� ũ�� ���� ������ ���������� ����
            float positionX = Random.Range(stagelimit.LimitMin.x, stagelimit.LimitMax.x);
            // �� ĳ���� ����
            GameObject enemyClone = Instantiate(enemy, new Vector3(positionX, stagelimit.LimitMax.y + 1.0f, 0.0f), Quaternion.identity);
            // �� ü���� ��Ÿ���� Slider UI ����
            EnemyHPSlider(enemyClone);
            // �� ���� ���� ����
            currentEnemyCount++;

            // ���� �ִ� ���ڱ��� �����ϸ� ���� ���� ����
            if (currentEnemyCount == maxEnemyCount)
            {
                //StartCoroutine("SpawnBoss");
                break;
            }
            // spawnTime��ŭ ���
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void EnemyHPSlider(GameObject enemy)
    {
        // �� ü���� ��Ÿ���� Slider UI ����
        GameObject sliderClone = Instantiate(enemyHPSlider);
        sliderClone.transform.SetParent(canvasTransform);
        // �ٲ� ũ�⸦ �ٽ� 1,1,1�� ����
        sliderClone.transform.localScale = Vector3.one;

        // Slider UI�� �Ѿƴٴ� ����� �������� ����
        sliderClone.GetComponent<SliderPositionAuto>().Setup(enemy.transform);
        // Slider UI�� ü�� ���� ǥ��
        sliderClone.GetComponent<EnemyHPViewer>().Setup(enemy.GetComponent<EnemyHP>());
    }

    private IEnumerator SpawnBoss()
    {
        //���� ���� BGM ����
        bgmController.ChangeBGM(BGMType.Boss); // bgmController.ChangeBGM(1); 

        // ���� ���� �ؽ�Ʈ Ȱ��ȭ
        Warningleft.SetActive(true);
        Warningright.SetActive(true);

        // 3�� ���
        yield return new WaitForSeconds(2.5f);

        // ���� ���� �ؽ�Ʈ ��Ȱ��ȭ
        Warningleft.SetActive(false);
        Warningright.SetActive(false);

        // ���� ü�� �����̴� Ȱ��ȭ
        bossHPSlider.SetActive(true);

        // ���� ������Ʈ Ȱ��ȭ
        boss.SetActive(true);

        // ������ ������ ��ġ�� �̵� ����
        boss.GetComponent<Boss>().ChangeState(BossState.MoveToAppearPoint);
    }
}

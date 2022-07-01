using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour // �÷��̾� 
{
    [SerializeField]
    private string nextSceneName;                       // ���� �� �̸�
    [SerializeField]
    private StageLimit stagelimit;                      // ȭ�� ��谪
    [SerializeField]
    private KeyCode keyCodeAttack = KeyCode.Space;      // Ű �ڵ� = �����̽�
    [SerializeField]
    private GameObject explosionPrefab;                 // ���� ȿ��
    private bool isdie = false;                         // ���� �Ǵ� ����
    private Movement movement;                          // �̵� ����
    private Bullet bullet;                              // �Ѿ�
    private int score;                                  // ����

    public int Score  // ���� �����ϰ� ������
    {
        // score ���� ������ ���� �ʵ���
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
        // ���� Ű�� ���� �̵� ���� ����
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        movement.MoveTo(new Vector3(x, y, 0));

        // ���� Ű�� Down/Up���� ���� ����/����
        if (Input.GetKeyDown(keyCodeAttack))
        {
            bullet.StartFiring(); // �Ѿ� �߻�
        }
        else if (Input.GetKeyUp(keyCodeAttack))
        {
            bullet.StopFiring(); // �Ѿ� �߻� ����
        }
    }

    private void LateUpdate() // �÷��̾� ĳ���Ͱ� ȭ�� �ٱ����� �� �������� ����
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stagelimit.LimitMin.x, stagelimit.LimitMax.x), 
            Mathf.Clamp(transform.position.y, stagelimit.LimitMin.y, stagelimit.LimitMax.y));
    }

    public void OnDie()
    {
        // �̵� ���� �ʱ�ȭ
        movement.MoveTo(Vector3.zero);
        // ���� �̺�Ʈ ����
        GameObject clone = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        // ����� �浹���� �ʵ��� �浹 �ڽ� ����
        Destroy(GetComponent<CircleCollider2D>());
        // ��� �� �÷��̾� ������ ���� ���ϰ� �ϴ� ����
        isdie = true;
        OnDieEvent();
    }

    public void OnDieEvent() 
    {
        // ȹ���� ���� score ����
        PlayerPrefs.SetInt("Score", score);
        // �÷��̾� ����� ���� ���� ������ �̵�
        SceneManager.LoadScene(nextSceneName);
    }
}

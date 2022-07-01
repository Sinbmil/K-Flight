using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour // 총알
{
    [SerializeField]
    private GameObject bullet;       // 공격할 때 생성되는 총알 

    [SerializeField]
    private float attackRate = 0.1f; // 공격 속도
    [SerializeField]
    private int maxAttackLevel = 5;  // 공격 최대 레벨
    private int attackLevel = 1;     // 공격 레벨
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
    public void StartFiring()        // 공격 시작
    {
        StartCoroutine("TryAttack");
    }

    public void StopFiring()        // 공격 중지
    {
        StopCoroutine("TryAttack");
    }

    private IEnumerator TryAttack()
    {
        while (true)
        {
            // 공격 레벨에 따라 총알 생성
            AttackByLevel();
            // 총알 사운드 재생
            audioSource.Play();

            // attackRate 시간만큼 대기
            yield return new WaitForSeconds(attackRate);
        }
    }

    
    private void AttackByLevel()     // 공격 레벨
    {
        GameObject cloneProjectile = null;

        switch(attackLevel)
        {
            case 1: // 레벨1 - 총알 1줄
                Instantiate(bullet, transform.position, Quaternion.identity);
                break;
            case 2: // 레벨2 - 총알 2줄
                Instantiate(bullet, transform.position + Vector3.left*0.2f, Quaternion.identity);
                Instantiate(bullet, transform.position + Vector3.right*0.2f, Quaternion.identity);
                break;
            case 3: // 레벨3 - 총알 3줄
                Instantiate(bullet, transform.position + Vector3.left * 0.2f, Quaternion.identity);
                Instantiate(bullet, transform.position, Quaternion.identity);
                Instantiate(bullet, transform.position + Vector3.right * 0.2f, Quaternion.identity);
                break;
            case 4: // 레벨4 - 양끝 총알 미세한 대각선 방향으로 발사
                Instantiate(bullet, transform.position, Quaternion.identity);
                cloneProjectile = Instantiate(bullet, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement>().MoveTo(new Vector3(-0.1f, 1, 0));

                cloneProjectile = Instantiate(bullet, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement>().MoveTo(new Vector3(0.1f, 1, 0));
                break;
            case 5: // 레벨5 - 양끝 총알 대각선 방향으로 발사
                Instantiate(bullet, transform.position, Quaternion.identity);
                cloneProjectile = Instantiate(bullet, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement>().MoveTo(new Vector3(-0.2f, 1, 0));

                cloneProjectile = Instantiate(bullet, transform.position, Quaternion.identity);
                cloneProjectile.GetComponent<Movement>().MoveTo(new Vector3(0.2f, 1, 0));
                break;
        }
    }
    
}

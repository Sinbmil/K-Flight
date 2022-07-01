using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType { BasicAttack=0, CircleFire=1, SingleFireToCenterPosition=2, TripleAttack=3}

public class BossWeapon : MonoBehaviour // 보스 무기 
{
    [SerializeField]
    private GameObject fire; // 보스가 공격할 때 생성되는 발사체
    
    public void StartFiring(AttackType attackType) // 공격 시작
    {
        StartCoroutine(attackType.ToString());
    }
    
    public void StopFiring(AttackType attackType) // 공격 중지
    {
        StopCoroutine(attackType.ToString());
    }

    private IEnumerator BasicAttack()
    {
        Vector3 targetPosition = Vector3.zero;
        GameObject cloneProjectile = null;
        float attackRate = 0.3f;

        while (true)
        {
            
            // 발사체 생성
            GameObject clone = Instantiate(fire, transform.position, Quaternion.identity);

            Vector3 direction = (targetPosition - clone.transform.position).normalized;

            cloneProjectile = Instantiate(fire, transform.position, Quaternion.identity);
            cloneProjectile.GetComponent<Movement>().MoveTo(new Vector3(0f, -1, 0));

            cloneProjectile = Instantiate(fire, transform.position, Quaternion.identity);
            cloneProjectile.GetComponent<Movement>().MoveTo(new Vector3(-0.4f, -1, 0));

            cloneProjectile = Instantiate(fire, transform.position, Quaternion.identity);
            cloneProjectile.GetComponent<Movement>().MoveTo(new Vector3(0.4f, -1, 0));

            // 발사체 이동 방향 설정
            clone.GetComponent<Movement>().MoveTo(direction);
            // attackRate만큼 대기
            yield return new WaitForSeconds(attackRate);
        }
    }

   private IEnumerator CircleFire()         // 2단계 원 공격
    {
        float attackRate = 0.8f;            // 공격 주기 
        int count = 30;                     // 발사체 생성 개수
        float intervalAngle = 360 / count;  // 발사체 시야 각도
        float weightAngle = 0;              // 가중되는 각도(항상 같은 위치로 발사하지 않도록 설정)

        while(true)
        {
            for(int i=0; i<count; ++i)
            {
                GameObject clone = Instantiate(fire, transform.position, Quaternion.identity);

                float angle = weightAngle + intervalAngle * i;

                float x = Mathf.Cos(angle * Mathf.PI / 180.0f);
                float y = Mathf.Sin(angle * Mathf.PI / 180.0f);
                clone.GetComponent<Movement>().MoveTo(new Vector2(x, y));
            }

            weightAngle += 1;

            yield return new WaitForSeconds(attackRate);
        }
    }

    private IEnumerator SingleFireToCenterPosition()   // 3단계 곡선 공격
    {
        Vector3 targetPosition = Vector3.zero;
        float attackRate = 0.15f;                       // 공격 주기 

        while (true)
        {
            // 발사체 생성
            GameObject clone = Instantiate(fire, transform.position, Quaternion.identity);
            // 발사체 이동 방향
            Vector3 direction = (targetPosition - clone.transform.position).normalized;
            // 발사체 이동 방향 설정
            clone.GetComponent<Movement>().MoveTo(direction);

            // attackRate만큼 대기
            yield return new WaitForSeconds(attackRate);
        }
    }

    private IEnumerator TripleAttack()                 // 4단계 곡선+총알추가 공격
    {
        Vector3 targetPosition = Vector3.zero;
        float attackRate = 0.4f;
        GameObject cloneProjectile = null;

        while (true)
        {
            // 발사체 생성
            GameObject clone = Instantiate(fire, transform.position, Quaternion.identity);
           
            // 발사체 이동 방향
            Vector3 direction = (targetPosition - clone.transform.position).normalized;
            cloneProjectile = Instantiate(fire, transform.position, Quaternion.identity);
            cloneProjectile.GetComponent<Movement>().MoveTo(new Vector3(-0.1f, -1, 0));

            cloneProjectile = Instantiate(fire, transform.position, Quaternion.identity);
            cloneProjectile.GetComponent<Movement>().MoveTo(new Vector3(0.1f, -1, 0));
            
            // 발사체 이동 방향 설정
            clone.GetComponent<Movement>().MoveTo(direction);

            // attackRate만큼 대기
            yield return new WaitForSeconds(attackRate);
        }
    }
}

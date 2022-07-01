using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType { BasicAttack=0, CircleFire=1, SingleFireToCenterPosition=2, TripleAttack=3}

public class BossWeapon : MonoBehaviour // ���� ���� 
{
    [SerializeField]
    private GameObject fire; // ������ ������ �� �����Ǵ� �߻�ü
    
    public void StartFiring(AttackType attackType) // ���� ����
    {
        StartCoroutine(attackType.ToString());
    }
    
    public void StopFiring(AttackType attackType) // ���� ����
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
            
            // �߻�ü ����
            GameObject clone = Instantiate(fire, transform.position, Quaternion.identity);

            Vector3 direction = (targetPosition - clone.transform.position).normalized;

            cloneProjectile = Instantiate(fire, transform.position, Quaternion.identity);
            cloneProjectile.GetComponent<Movement>().MoveTo(new Vector3(0f, -1, 0));

            cloneProjectile = Instantiate(fire, transform.position, Quaternion.identity);
            cloneProjectile.GetComponent<Movement>().MoveTo(new Vector3(-0.4f, -1, 0));

            cloneProjectile = Instantiate(fire, transform.position, Quaternion.identity);
            cloneProjectile.GetComponent<Movement>().MoveTo(new Vector3(0.4f, -1, 0));

            // �߻�ü �̵� ���� ����
            clone.GetComponent<Movement>().MoveTo(direction);
            // attackRate��ŭ ���
            yield return new WaitForSeconds(attackRate);
        }
    }

   private IEnumerator CircleFire()         // 2�ܰ� �� ����
    {
        float attackRate = 0.8f;            // ���� �ֱ� 
        int count = 30;                     // �߻�ü ���� ����
        float intervalAngle = 360 / count;  // �߻�ü �þ� ����
        float weightAngle = 0;              // ���ߵǴ� ����(�׻� ���� ��ġ�� �߻����� �ʵ��� ����)

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

    private IEnumerator SingleFireToCenterPosition()   // 3�ܰ� � ����
    {
        Vector3 targetPosition = Vector3.zero;
        float attackRate = 0.15f;                       // ���� �ֱ� 

        while (true)
        {
            // �߻�ü ����
            GameObject clone = Instantiate(fire, transform.position, Quaternion.identity);
            // �߻�ü �̵� ����
            Vector3 direction = (targetPosition - clone.transform.position).normalized;
            // �߻�ü �̵� ���� ����
            clone.GetComponent<Movement>().MoveTo(direction);

            // attackRate��ŭ ���
            yield return new WaitForSeconds(attackRate);
        }
    }

    private IEnumerator TripleAttack()                 // 4�ܰ� �+�Ѿ��߰� ����
    {
        Vector3 targetPosition = Vector3.zero;
        float attackRate = 0.4f;
        GameObject cloneProjectile = null;

        while (true)
        {
            // �߻�ü ����
            GameObject clone = Instantiate(fire, transform.position, Quaternion.identity);
           
            // �߻�ü �̵� ����
            Vector3 direction = (targetPosition - clone.transform.position).normalized;
            cloneProjectile = Instantiate(fire, transform.position, Quaternion.identity);
            cloneProjectile.GetComponent<Movement>().MoveTo(new Vector3(-0.1f, -1, 0));

            cloneProjectile = Instantiate(fire, transform.position, Quaternion.identity);
            cloneProjectile.GetComponent<Movement>().MoveTo(new Vector3(0.1f, -1, 0));
            
            // �߻�ü �̵� ���� ����
            clone.GetComponent<Movement>().MoveTo(direction);

            // attackRate��ŭ ���
            yield return new WaitForSeconds(attackRate);
        }
    }
}

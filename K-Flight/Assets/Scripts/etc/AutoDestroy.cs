using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour // ȭ�� ������ ������ ������Ʈ �ڵ� ����
{
    [SerializeField]
    private StageLimit stagelimit;
    private float destroyWeight = 2.0f;

    private void LateUpdate()
    {
        if(transform.position.y < stagelimit.LimitMin.y - destroyWeight ||
           transform.position.y > stagelimit.LimitMax.y + destroyWeight ||
           transform.position.x < stagelimit.LimitMin.x - destroyWeight ||
           transform.position.x > stagelimit.LimitMax.x + destroyWeight)
        {
            Destroy(gameObject);
        }
    }
}

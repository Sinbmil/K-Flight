using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPositionAuto : MonoBehaviour // ü���� ��Ÿ���� �����̵�
{
    [SerializeField]
    private Vector3 distance = Vector3.down * 50.0f;
    private Transform targetTransform;
    private RectTransform rectTransform;

    public void Setup(Transform target)
    {
        // Slider UI�� �Ѿƴٴ� target ����
        targetTransform = target;
        // RectTransform ������Ʈ ���� ������
        rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        // ���� ����Ǹ� Slider UI�� ����
        if(targetTransform == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetTransform.position);
        rectTransform.position = screenPosition + distance;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPositionAuto : MonoBehaviour // 체력을 나타내는 슬라이드
{
    [SerializeField]
    private Vector3 distance = Vector3.down * 50.0f;
    private Transform targetTransform;
    private RectTransform rectTransform;

    public void Setup(Transform target)
    {
        // Slider UI가 쫓아다닐 target 설정
        targetTransform = target;
        // RectTransform 컴포넌트 정보 얻어오기
        rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        // 적이 사망되면 Slider UI도 삭제
        if(targetTransform == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetTransform.position);
        rectTransform.position = screenPosition + distance;
    }
}

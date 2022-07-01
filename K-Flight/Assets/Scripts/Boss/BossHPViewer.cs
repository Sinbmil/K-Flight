using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPViewer : MonoBehaviour // 보스 HP Slider
{
    [SerializeField]
    private BossHP bossHP;
    private Slider sliderHP;
   
    private void Awake()
    {
        sliderHP = GetComponent<Slider>();
    }

    private void Update()
    {
        // Slider UI에 체력 정보 업데이트
        sliderHP.value = bossHP.CurrentHP / bossHP.MaxHP;
    }
}

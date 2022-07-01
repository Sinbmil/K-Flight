using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour // 점수
{
    [SerializeField]
    private PlayerController PlayerController;
    private TextMeshProUGUI scoretext;

    private void Awake()
    {
        scoretext = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        // 현재 스코어 점수 출력하기
        scoretext.text = "Score " + PlayerController.Score;
    }
}

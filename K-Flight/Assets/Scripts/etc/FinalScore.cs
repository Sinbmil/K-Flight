using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour // 최종 점수
{
    private TextMeshProUGUI textFinalScore;

    private void Awake()
    {
        textFinalScore = GetComponent<TextMeshProUGUI>();
        // 메인 게임에서 저장한 점수를 불러와서 score 변수에 저장
        int score = PlayerPrefs.GetInt("Score");
        textFinalScore.text = "Score " + score;
    }
}

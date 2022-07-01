using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour  // 최고 점수
{
    private TextMeshProUGUI textFinalScore;
    private TextMeshProUGUI textHighScore;

    private void Start()
    {
        textHighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    private void Awake()
    {
        textFinalScore = GetComponent<TextMeshProUGUI>();
        textHighScore = GetComponent<TextMeshProUGUI>();
        // 메인 게임에서 저장한 점수를 불러와서 score 변수에 저장
        int score = PlayerPrefs.GetInt("Score");
        if(score>PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        textHighScore.text = "HighScore " + score;
    }
}

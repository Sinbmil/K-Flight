using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour  // �ְ� ����
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
        // ���� ���ӿ��� ������ ������ �ҷ��ͼ� score ������ ����
        int score = PlayerPrefs.GetInt("Score");
        if(score>PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        textHighScore.text = "HighScore " + score;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour // ���� ����
{
    private TextMeshProUGUI textFinalScore;

    private void Awake()
    {
        textFinalScore = GetComponent<TextMeshProUGUI>();
        // ���� ���ӿ��� ������ ������ �ҷ��ͼ� score ������ ����
        int score = PlayerPrefs.GetInt("Score");
        textFinalScore.text = "Score " + score;
    }
}

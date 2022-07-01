using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour // ����
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
        // ���� ���ھ� ���� ����ϱ�
        scoretext.text = "Score " + PlayerController.Score;
    }
}

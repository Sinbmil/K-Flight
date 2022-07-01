using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossExplosion : MonoBehaviour  // ���� ���Ľ�
{
    private PlayerController playerController;
    private string sceneName;

    public void Setup(PlayerController playerController, string sceneName)
    {
        this.playerController = playerController;
        this.sceneName = sceneName;
    }

    private void OnDestroy()
    {
        // �÷��̾� ������ score�� ����
        PlayerPrefs.SetInt("Score", playerController.Score);
        // ���� �� �ҷ�����
        SceneManager.LoadScene(sceneName);
    }
}

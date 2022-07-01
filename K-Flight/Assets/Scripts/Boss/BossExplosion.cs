using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossExplosion : MonoBehaviour  // 보스 폭파시
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
        // 플레이어 점수를 score에 저장
        PlayerPrefs.SetInt("Score", playerController.Score);
        // 다음 씬 불러오기
        SceneManager.LoadScene(sceneName);
    }
}

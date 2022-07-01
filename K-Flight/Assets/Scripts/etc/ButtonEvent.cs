using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour // 버튼 설정
{
    public void SceneLoader(string sceneName) // 씬 전환
   {
        SceneManager.LoadScene(sceneName);
    }

    public void OnClickExit()                // 프로그램 종료
    {
        Application.Quit();
    }
}

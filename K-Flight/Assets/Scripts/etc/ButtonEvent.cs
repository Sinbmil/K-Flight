using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour // ��ư ����
{
    public void SceneLoader(string sceneName) // �� ��ȯ
   {
        SceneManager.LoadScene(sceneName);
    }

    public void OnClickExit()                // ���α׷� ����
    {
        Application.Quit();
    }
}

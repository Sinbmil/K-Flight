using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BGMType { Stage=0, Boss }

public class BGMController : MonoBehaviour // BGM 설정
{
    [SerializeField]
    private AudioClip[] bgmClips; // 배경음악 파일 목록
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeBGM(BGMType index)
    {
        // 현재 재생중인 배경음악 정지
        audioSource.Stop();

        // 배경음악 파일 목록에서 index 음악으로 교체
        audioSource.clip = bgmClips[(int)index];
        // 바뀐 음악파일 재생
        audioSource.Play();
    }
}

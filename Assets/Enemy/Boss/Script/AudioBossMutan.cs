using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBossMutan : MonoBehaviour
{
    [Header("List Audio for Boss animator")]
    [SerializeField]
    private List<AudioClip> audioClipsWalking;

    [SerializeField]
    private List<AudioClip> audioClipsRoaring;

    [SerializeField]
    private List<AudioClip> audioClipsAttack01;
    [SerializeField]
    private List<AudioClip> audioClipsAttack02;
    [SerializeField]
    private List<AudioClip> audioClipsAttack03;

    [SerializeField]
    private AudioSource audioSource;

    private int pos;


    public void SetSoundWalkingBoss()
    {
        pos = (int)Mathf.Floor(Random.Range(0, audioClipsWalking.Count));
        audioSource.PlayOneShot(audioClipsWalking[pos]);
    }
    public void SetSoundBossRoaring()
    {
        audioSource.PlayOneShot(audioClipsRoaring[0]);
    }
    public void SetSoundBossAttack01()
    {
        audioSource.PlayOneShot(audioClipsAttack01[0]);
    }
    public void SetSoundBossAttack02()
    {
        audioSource.PlayOneShot(audioClipsAttack02[0]);
    }
    public void SetSoundBossAttack03()
    {
        audioSource.PlayOneShot(audioClipsAttack03[0]);
    }
}

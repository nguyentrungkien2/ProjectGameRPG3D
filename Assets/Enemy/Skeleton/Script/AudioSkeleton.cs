using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSkeleton : MonoBehaviour
{
    [Header("List Audio for Skeleton animator")]

    [SerializeField]
    private List<AudioClip> audioClipsWarning;

    [SerializeField]
    private List<AudioClip> audioClipsAttack01;
    [SerializeField]
    private List<AudioClip> audioClipsAttack02;
    [SerializeField]
    private List<AudioClip> audioClipsAttack03;

    [SerializeField]
    private AudioSource audioSource;

    private int pos;


    public void SetSoundSkeletonWarning()
    {
        audioSource.PlayOneShot(audioClipsWarning[0]);
    }
    public void SetSoundSkeletonAttack01()
    {
        audioSource.PlayOneShot(audioClipsAttack01[0]);
    }
    public void SetSoundSkeletonAttack02()
    {
        audioSource.PlayOneShot(audioClipsAttack02[0]);
    }
    public void SetSoundSkeletonAttack03()
    {
        audioSource.PlayOneShot(audioClipsAttack03[0]);
    }
}

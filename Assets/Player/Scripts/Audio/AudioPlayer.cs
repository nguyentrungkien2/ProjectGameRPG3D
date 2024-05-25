using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("List Audio for player animator")]
    [SerializeField]
    private List<AudioClip> audioClipsWalking;

    [SerializeField]
    private List<AudioClip> audioClipsJumpStart; 

    [SerializeField]
    private List<AudioClip> audioClipsJumpEnd;

    [SerializeField] 
    private List<AudioClip> audioClipsAttack01;
    [SerializeField]
    private List<AudioClip> audioClipsAttack02;
    [SerializeField]
    private List<AudioClip> audioClipsAttack03;
    [SerializeField]
    private List<AudioClip> audioClipsPlayerDie;
    [SerializeField]
    private List<AudioClip> audioClipsPlayerGetHit;

    [SerializeField]
    private AudioSource audioSource;

    private int pos;

    public void SetSoundWalkingPlayer()
    {
        pos = (int)Mathf.Floor(Random.Range(0, audioClipsWalking.Count));
        audioSource.PlayOneShot(audioClipsWalking[pos]);
    }  
    
    public void SetSoundJumpPlayerStart()
    {
        audioSource.PlayOneShot(audioClipsJumpStart[0]);
    }
    public void SetSoundJumpPlayerEnd()
    {
        audioSource.PlayOneShot(audioClipsJumpEnd[0]);
    }
    public void SetSoundAttackPlayer01()
    {
        audioSource.PlayOneShot(audioClipsAttack01[0]);
        audioSource.PlayOneShot(audioClipsAttack01[1]);
    }
    public void SetSoundAttackPlayer02()
    {
        audioSource.PlayOneShot(audioClipsAttack02[0]);
        audioSource.PlayOneShot(audioClipsAttack02[1]);
    }
    public void SetSoundAttackPlayer03()
    {
        audioSource.PlayOneShot(audioClipsAttack03[0]);
        audioSource.PlayOneShot(audioClipsAttack03[1]);
    }
    public void SetSoundDiePlayer()
    {
        audioSource.PlayOneShot(audioClipsPlayerDie[0]);
    }
    public void SetSoundGetHitPlayer()
    {
        audioSource.PlayOneShot(audioClipsPlayerGetHit[0]);
    }
}

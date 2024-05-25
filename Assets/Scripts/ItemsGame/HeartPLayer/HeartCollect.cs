using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HeartCollect : MonoBehaviour
{
    private static int RotateSpeed=4;
    public AudioSource CollectSound;
    public GameObject ThisHeart;
    private TakeDamePlayerManager TakeDamePlayerManager;
    private int plustHpPlayer = -1;


    void Update()
    {
        transform.Rotate(0, RotateSpeed, 0, Space.World);
    }

    public void OnTriggerEnter(Collider other)
    {
        CollectSound.Play();
        other.GetComponent<TakeDamePlayerManager>().TakeDame(plustHpPlayer);
        Destroy(gameObject);
    }
}

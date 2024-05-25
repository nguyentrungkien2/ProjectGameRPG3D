using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EdenAI;
using System;
using System.Threading.Tasks;

public class NPCMan : MonoBehaviour
{
    public GameObject ActionDisplay;
    public GameObject ActionText;


    public GameObject TextBox;
    public GameObject NPCName;
    public TMP_Text NPCText;
    public GameObject TextBoxQuest;
    private float theDistance;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerStay(Collider other)
    {
        theDistance = PlayerCasting.DistanceFromTarget;
        if (theDistance <= 24)
        {
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                TextBoxQuest.SetActive(true);
                StartCoroutine(NPC001Active());
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

    IEnumerator NPC001Active()
    {
        animator.SetBool("Talking", true);
        TextBox.gameObject.SetActive(true);
        NPCName.SetActive(true);
        NPCText.text = "Chào Nhi tôi biết phù thuỷ cô đơn ở đâu tôi sẻ chỉ cho bạn, bạn hãy đến nhà của ông ta phía bên kia cây cầu, bạn có thể đi theo mũi tên hướng dẫn màu xanh lam ở chân";
        NPCText.gameObject.SetActive(true);
        yield return new WaitForSeconds(10.0f);
        NPCName.SetActive(false);
        animator.SetBool("Talking", false);
        NPCText.gameObject.SetActive(false);
        TextBox.gameObject.SetActive(false);
        ActionDisplay.gameObject.SetActive(true);
        ActionText.gameObject.SetActive(true);

    }
}


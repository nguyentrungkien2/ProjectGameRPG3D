using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NPCMagicianLevel02 : MonoBehaviour
{

    [SerializeField] private GameObject playerAction;
    [SerializeField] private TMP_Text textAction;

    [SerializeField] private float distance;
    [SerializeField] private GameObject texBoxMagician;
    [SerializeField] private GameObject textDescriptionMagician01;
    [SerializeField] private GameObject textDescriptionMagician02;
    [SerializeField] private GameObject textDescriptionMagician03;

    private Animator animator;
    //textbox player
    [SerializeField] private GameObject texBoxPlayer;
    [SerializeField] private GameObject textDescriptionPlayer01vsMagician;
    [SerializeField] private GameObject textDescriptionPlayer02vsMagician;

    private float theDistance;


    [SerializeField] private GameObject quest01ComBat;
    private bool interacted = false; // Biến cờ để kiểm tra xem đã tương tác với NPC trước đó chưa

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OnTriggerStay(Collider other)
    {
        if (!interacted)
        {
            distance = PlayerCasting.DistanceFromTarget;
            if (distance <= 24)
            {
                playerAction.SetActive(true);
                textAction.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interacted = true; // Đánh dấu là đã tương tác với NPC
                    playerAction.SetActive(false);
                    textAction.gameObject.SetActive(false);
                    StartCoroutine(TextBoxDislay());
                }
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        playerAction.SetActive(false);
        textAction.gameObject.SetActive(false);
    }
    IEnumerator TextBoxDislay()
    {
        playerAction.SetActive(false);
        textAction.gameObject.SetActive(false);
        textAction.text = "Nói chuyện";
        animator.SetBool("Talking", true);
        texBoxPlayer.gameObject.SetActive(false);
        texBoxMagician.gameObject.SetActive(true);
        textDescriptionMagician01.gameObject.SetActive(true);
        yield return new WaitForSeconds(8);

        animator.SetBool("Talking", false);
        texBoxMagician.gameObject.SetActive(false);
        texBoxPlayer.gameObject.SetActive(true);
        textDescriptionMagician01.gameObject.SetActive(false);
        textDescriptionPlayer01vsMagician.gameObject.SetActive(true);
        yield return new WaitForSeconds(10);

        animator.SetBool("Talking", true);
        texBoxMagician.gameObject.SetActive(true);
        texBoxPlayer.gameObject.SetActive(false);
        textDescriptionPlayer01vsMagician.gameObject.SetActive(false);
        textDescriptionMagician02.gameObject.SetActive(true);
        yield return new WaitForSeconds(9);

        animator.SetBool("Talking", false);
        texBoxMagician.gameObject.SetActive(false);
        texBoxPlayer.gameObject.SetActive(true);
        textDescriptionMagician02.gameObject.SetActive(false);
        textDescriptionPlayer02vsMagician.gameObject.SetActive(true);
        yield return new WaitForSeconds(9);

        animator.SetBool("Talking", true);
        texBoxMagician.gameObject.SetActive(true);
        texBoxPlayer.gameObject.SetActive(false);
        textDescriptionPlayer02vsMagician.gameObject.SetActive(false);
        textDescriptionMagician02.gameObject.SetActive(false);
        textDescriptionMagician03.gameObject.SetActive(true);

        yield return new WaitForSeconds(9);
        animator.SetBool("Talking", false);
        textDescriptionMagician03.gameObject.SetActive(false);
        texBoxMagician.gameObject.SetActive(false);
        textDescriptionPlayer02vsMagician.SetActive(false);
        textDescriptionPlayer01vsMagician.SetActive(false);
        yield return new WaitForSeconds(2);

        quest01ComBat.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
    }
}

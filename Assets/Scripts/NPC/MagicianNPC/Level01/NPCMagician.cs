using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCMagician : MonoBehaviour
{
    [SerializeField] private GameObject playerAction;
    [SerializeField] private TMP_Text textAction;

    [SerializeField] private float distance;
    [SerializeField] private GameObject texBoxMagician;
    [SerializeField] private TMP_Text textName;
    [SerializeField] private GameObject textDescriptionMagician01;
    [SerializeField] private GameObject textDescriptionMagician02;
    [SerializeField] private GameObject textDescriptionMagician03;

    //textbox player
    [SerializeField] private GameObject texBoxPlayer;
    [SerializeField] private TMP_Text textNamePlayer;
    [SerializeField] private GameObject textDescriptionPlayer01vsMagician;
    [SerializeField] private GameObject textDescriptionPlayer02vsMagician;

    private float theDistance;

    //Sword
    [SerializeField] private GameObject sword;
    //Take Sword
    [SerializeField] private GameObject takeSword;

    [SerializeField] private ParticleSystem particleLightSword;
    [SerializeField] private Light lightSword;

    [SerializeField] private GameObject quest01ComBat;
    private bool interacted = false; // Biến cờ để kiểm tra xem đã tương tác với NPC trước đó chưa
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
        texBoxPlayer.gameObject.SetActive(false);
        texBoxMagician.gameObject.SetActive(true);
        textName.text = "Pháp sư Cô đơn";
        textDescriptionMagician01.gameObject.SetActive(true);
        yield return new WaitForSeconds(8);

        texBoxMagician.gameObject.SetActive(false);
        texBoxPlayer.gameObject.SetActive(true);
        textNamePlayer.text = "Nhi Player";
        textDescriptionPlayer01vsMagician.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);

        texBoxMagician.gameObject.SetActive(true);
        texBoxPlayer.gameObject.SetActive(false);
        textName.text = "Pháp sư Cô đơn";
        textDescriptionMagician01.gameObject.SetActive(false);
        textDescriptionMagician02.gameObject.SetActive(true);
        yield return new WaitForSeconds(7);

        texBoxMagician.gameObject.SetActive(false);
        texBoxPlayer.gameObject.SetActive(true);
        textNamePlayer.text = "Nhi Player";
        textDescriptionPlayer01vsMagician.gameObject.SetActive(false);
        textDescriptionPlayer02vsMagician.gameObject.SetActive(true);
        yield return new WaitForSeconds(7);

        texBoxMagician.gameObject.SetActive(true);
        texBoxPlayer.gameObject.SetActive(false);
        textName.text = "Pháp sư Cô đơn";
        textDescriptionPlayer02vsMagician.gameObject.SetActive(false);
        textDescriptionMagician02.gameObject.SetActive(false);
        textDescriptionMagician03.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        textDescriptionMagician03.gameObject.SetActive(false);
        texBoxMagician.gameObject.SetActive(false);
        sword.gameObject.SetActive(true);
        particleLightSword.Play();
        lightSword.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);

        quest01ComBat.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);

        Destroy(quest01ComBat.gameObject);      
    }
}

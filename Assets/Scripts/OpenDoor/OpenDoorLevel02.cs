using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OpenDoorLevel02 : MonoBehaviour
{
    [SerializeField] private GameObject actionPlayer;
    [SerializeField] private TMP_Text actionText;
    [SerializeField] private Animation openDoor;
    private float theDistance;

    private bool isOpenDoor = false;

    void OnTriggerStay(Collider other)
    {
        if (!isOpenDoor)
        {
            theDistance = PlayerCasting.DistanceFromTarget;
            if (theDistance <= 4)
            {
                actionText.text = "Mở cửa";
                actionPlayer.SetActive(true);
                actionText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    QuestManager.SubQuestNumber = 2;
                    isOpenDoor = true;
                    openDoor.Play();
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        actionPlayer.SetActive(false);
        actionText.gameObject.SetActive(false);
    }
}

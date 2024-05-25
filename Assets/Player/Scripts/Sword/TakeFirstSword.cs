using UnityEngine;
using TMPro;

public class TakeFirstSword : MonoBehaviour
{
    public GameObject swordPlayer;
    [SerializeField] private GameObject actionPlayer;
    [SerializeField] private TMP_Text actionSword;
    [SerializeField] private GameObject displayBear;

    private bool canInteract = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
            actionPlayer.SetActive(true);
            actionSword.gameObject.SetActive(true);
            actionSword.text = "Lấy thanh kiếm";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            actionPlayer.SetActive(false);
            actionSword.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject);
            swordPlayer.SetActive(true);
            actionPlayer.SetActive(false);
            actionSword.gameObject.SetActive(false);
            displayBear.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    public static int ActiveQuestNumber;
    public int InternalQuestNumber;

    public GameObject MainMark;
    public GameObject Objective01Mark;
    public GameObject Objective02Mark;
    public GameObject Objective03Mark;
    public GameObject Objective04Mark;
    public static int SubQuestNumber;
    public int InternalSubNumber;
    public GameObject Pointer;

    void Update()
    {
        InternalQuestNumber = ActiveQuestNumber;
        InternalSubNumber = SubQuestNumber;
        Pointer.transform.LookAt(MainMark.transform);

        if (InternalSubNumber == 0)
        {
            Pointer.SetActive(false);
        }
        else
        {
            Pointer.SetActive(true);
        }

        if (InternalSubNumber == 1)
        {
            MainMark.transform.position = Objective01Mark.transform.position;
        }

        if (InternalSubNumber == 2)
        {
            MainMark.transform.position = Objective02Mark.transform.position;
        }

        if (InternalSubNumber == 3)
        {
            MainMark.transform.position = Objective03Mark.transform.position;
        }
        if (InternalSubNumber == 4)
        {
            MainMark.transform.position = Objective04Mark.transform.position;
        }
    }

}

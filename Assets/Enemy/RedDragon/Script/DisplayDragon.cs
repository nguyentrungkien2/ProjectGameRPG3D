using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayDragon : MonoBehaviour
{
    [SerializeField] private GameObject dragon;
    [SerializeField] private GameObject quest02;

    [SerializeField] private GameObject textBoxPLayer;
    [SerializeField] private GameObject descriptionPLayer01;
    [SerializeField] private GameObject descriptionPLayer02;

    [SerializeField] private GameObject textBoxDragon;
    [SerializeField] private GameObject descriptionDragon01;
    [SerializeField] private GameObject descriptionDragon02;
    [SerializeField] private GameObject descriptionDragon03;

    //public Light lightLevel01;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(EventPlayerCollision());
        }    
    }
    public IEnumerator EventPlayerCollision()
    {

        yield return new WaitForSecondsRealtime(2);
        var col = GetComponent<Collider>();
        col.enabled = false;
        //lightLevel01=GameObject.Find("Directional Light").gameObject.GetComponent<Light>();
        //lightLevel01.enabled = false;
        textBoxDragon.gameObject.SetActive(true);
        descriptionDragon01.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(6);

        textBoxDragon.gameObject.SetActive(false);
        textBoxPLayer.gameObject.SetActive(true);
        descriptionDragon01.gameObject.SetActive(false);
        descriptionPLayer01.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(6);

        textBoxDragon.gameObject.SetActive(true);
        textBoxPLayer.gameObject.SetActive(false);
        descriptionPLayer01.gameObject.SetActive(false);
        descriptionDragon01.gameObject.SetActive(false);
        descriptionDragon02.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(8);

        textBoxDragon.gameObject.SetActive(false);
        textBoxPLayer.gameObject.SetActive(true);
        descriptionDragon02.gameObject.SetActive(false);
        descriptionPLayer01.gameObject.SetActive(false);
        descriptionPLayer02.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(8);

        descriptionPLayer02.gameObject.SetActive(false);
        textBoxDragon.gameObject.SetActive(true);
        textBoxPLayer.gameObject.SetActive(false);
        descriptionDragon03.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(5);

        descriptionDragon03.gameObject.SetActive(false);
        textBoxDragon.gameObject.SetActive(false);
        quest02.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(4);
        quest02.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(1);
        dragon.gameObject.SetActive(true);

    }    

}

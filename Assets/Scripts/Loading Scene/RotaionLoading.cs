using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaionLoading : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f; // Tốc độ quay của đối tượng

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}

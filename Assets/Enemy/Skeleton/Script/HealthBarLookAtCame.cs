using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarLookAtCame : MonoBehaviour
{
    private GameObject targetLookAt;

    void Start()
    {
        // Tìm đối tượng có tag "Player" trong scene và gán cho targetLookAt
        targetLookAt = GameObject.FindGameObjectWithTag("Player");

        // Kiểm tra xem có tìm thấy đối tượng không
        if (targetLookAt == null)
        {
            Debug.LogError("No object with tag 'Player' found in the scene!");
        }
    }

    void Update()
    {
        // Chỉ quay đối tượng nếu targetLookAt được gán
        if (targetLookAt != null)
        {
            transform.LookAt(targetLookAt.transform.position);
        }
    }
}

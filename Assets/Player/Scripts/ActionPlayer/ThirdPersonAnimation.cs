﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private float maxSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Update()
    {
        animator.SetFloat("speed", rb.velocity.magnitude / maxSpeed);
    }

    // Called when the player collides with another object
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hit by Attack"))
        {
            animator.SetTrigger("Get Hit");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE (child class)
public class Bobcat : Animal
{
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        animalRb = GetComponent<Rigidbody>();

        animalHealth = 4;
        animalStrength = 10;
        animalSpeed = 5f;
        jumpForce = 8f;
        isFriendly = false;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateDistance();
        Move();   
    }

    // POLYMORPHISM
    public override void Move()
    {
        if (player != null)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            animalRb.AddForce(lookDirection * animalSpeed, ForceMode.Force);
        }

        if (CalculateDistance() < 12f && isGrounded)
            Jump();

        if (CalculateDistance() > 25f)
            animalSpeed = 10f;
        else
            animalSpeed = 5f;
    }
}

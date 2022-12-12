using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE (child class)
public class Bunny : Animal
{
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        animalRb = GetComponent<Rigidbody>();

        animalHealth = 10;
        animalStrength = 1;
        animalSpeed = 5f;
        jumpForce = 5f;
        isFriendly = true;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateDistance();
        Move();

        if (isGrounded)
            Jump();
    }
}

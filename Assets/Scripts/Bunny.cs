using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : Animal
{
    [SerializeField] float jumpForce = 5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        animalRb = GetComponent<Rigidbody>();

        animalHealth = 10;
        animalStrength = 1;
        animalSpeed = 5f;
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

    private void Jump()
    {
        animalRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }
}

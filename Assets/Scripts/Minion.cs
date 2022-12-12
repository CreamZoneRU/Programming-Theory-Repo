using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : Animal
{
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        animalRb = GetComponent<Rigidbody>();

        animalHealth = 2;
        animalStrength = 1;
        animalSpeed = 3f;
        isFriendly = false;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateDistance();
        Move();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : Animal
{
    [SerializeField] private bool isHiding = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        animalRb = GetComponent<Rigidbody>();

        animalHealth = 2;
        animalStrength = 5;
        animalSpeed = 3f;
        isFriendly = false;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateDistance();
        Move();

        if (CalculateDistance() > 15f && !isHiding)
        {
            isHiding = true;
            transform.position = transform.localPosition + new Vector3 (0, -6, 0);
            animalSpeed = 1.5f;
        }

        else if (CalculateDistance() < 15f && isHiding)
        {
            transform.position = transform.localPosition - new Vector3(0, -6, 0);
            animalSpeed = 3f;
            isHiding = false;
        }           
    }
}

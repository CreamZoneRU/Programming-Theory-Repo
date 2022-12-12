using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    protected Rigidbody animalRb;
    protected PlayerController player;

    protected int animalHealth;
    protected int animalStrength;
    protected float animalSpeed;
    protected float jumpForce;
    protected float distanceToThePlayer;
    protected bool isGrounded;
    protected bool isFriendly;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        animalRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateDistance();
        Move();
    }

    public virtual float CalculateDistance()
    {
        if(player != null)
        {
            Vector3 mainObject = transform.position;
            Vector3 followObject = player.transform.position;

            distanceToThePlayer = Vector3.Distance(mainObject, followObject);
        }
        return distanceToThePlayer;
    }

    public virtual void DealDamage()
    {
        player.playerHealth -= animalStrength;
        Debug.Log($"Player Health: {player.playerHealth}");
    }

    public virtual void Move()
    {
        if (player != null)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            animalRb.AddForce(lookDirection * animalSpeed, ForceMode.Force);
        }
    }

    public virtual void Jump()
    {
        animalRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"Player Touched by {gameObject.name}!");

            // If animal is friendly it can't hurt you and you can't hurt him
            if (!isFriendly)
            {
                DealDamage();
                animalHealth -= player.playerStrength;
            }

            // If animal health less or equal 0 it dies
            if (animalHealth <= 0)
                Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}

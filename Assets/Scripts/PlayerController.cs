using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] int playerHealth = 3;
    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;

    private Rigidbody playerRb;
    private Animal animalScript;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        animalScript = GameObject.FindGameObjectWithTag("Animal").GetComponent<Animal>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Z-axis movement
        playerRb.AddForce(horizontalInput * playerSpeed * Vector3.right);
        // X-axis movement
        playerRb.AddForce(playerSpeed * verticalInput * Vector3.forward);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Animal"))
        {
            animalScript.animalHealth -= 1;
            if (animalScript.animalHealth <= 0)
            {
                Destroy(collision.gameObject);
            }
            playerHealth -= animalScript.animalStrength;

            Debug.Log($"Player Health: {playerHealth}");
        }
    }
}

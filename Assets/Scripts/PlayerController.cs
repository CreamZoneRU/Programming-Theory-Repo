using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;
    public int playerHealth = 10;
    public int playerStrength = 2;

    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;

    private Rigidbody playerRb;
    public static PlayerController Player;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Z-axis movement
        playerRb.AddForce(horizontalInput * playerSpeed * Vector3.right, ForceMode.Force);
        // X-axis movement
        playerRb.AddForce(playerSpeed * verticalInput * Vector3.forward, ForceMode.Force);

        if(playerHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("You Died!");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private GameObject player;
    private Rigidbody animalRb;

    [SerializeField] float speed = 700f;
    public int animalHealth = 1;
    public int animalStrength = 1;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        animalRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        animalRb.AddForce(lookDirection * speed * Time.deltaTime);
    }


}

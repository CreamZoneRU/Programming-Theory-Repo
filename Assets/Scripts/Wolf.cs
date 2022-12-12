using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE (child class)
public class Wolf : Animal
{
    private float spawnRange = 5f;
    private int minionsCount;
    [SerializeField] private GameObject minionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        animalRb = GetComponent<Rigidbody>();

        animalHealth = 6;
        animalStrength = 4;
        animalSpeed = 4f;
        isFriendly = false;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateDistance();
        Move();

        minionsCount = GameObject.FindGameObjectsWithTag("Minion").Length;

        if (minionsCount == 0)
            SpawnMinionWave(3);
    }

    // ABSTRACTION
    private void SpawnMinionWave(int minionsToSpawn)
    {
        for (int i = 0; i < minionsToSpawn; i++)
            Instantiate(minionPrefab, GenerateSpawnPosition(), minionPrefab.transform.rotation);
    }

    // ABSTRACTION
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(transform.position.x + -spawnRange, transform.position.x + spawnRange);
        float spawnPosZ = Random.Range(transform.position.z + -spawnRange,transform.position.z + spawnRange);

        Vector3 randomPos = new(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

    // POLYMORPHISM
    protected override void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && player.isBleeding == false)
        {
            DealDamage();
            animalHealth -= player.playerStrength;

            // If animal health less or equal 0 it dies
            if (animalHealth <= 0)
                Destroy(gameObject);

            StartCoroutine(Bleed());
        }
    }

    // ABSTRACTION
    private IEnumerator Bleed()
    {
        player.isBleeding = true;

        for (int i = 0; i < 4; i++)
        {
            player.playerHealth--;
            animalHealth++;

            yield return new WaitForSeconds(1);
        }  

        player.isBleeding = false;
    }
}

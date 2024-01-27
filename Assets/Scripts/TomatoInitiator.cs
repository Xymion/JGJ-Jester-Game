using UnityEngine;
using System.Collections;

public class TomatoInitiator : MonoBehaviour
{
    public GameObject tomatoPrefab;
    public int numberOfProjectiles = 5;
    public float cooldownTime = 5f;
    public float tomatoLifetime = 3f;
    public float initialSpeed = 5f; // Adjust the initial speed as needed

    private float lastSpawnTime;

    void Start()
    {
        lastSpawnTime = Time.time;
        StartCoroutine(SpawnTomatoes());
    }

    IEnumerator SpawnTomatoes()
    {
        while (true)
        {
            // Check if the cooldown time has passed before spawning a tomato
            if (Time.time - lastSpawnTime >= cooldownTime)
            {
                // Determine a random position outside the play area
                float spawnX = Random.Range(-12f, -15f); // Adjust the range as needed
                float spawnY = Random.Range(-5f, 5f);
                Vector2 spawnPosition = new Vector2(spawnX, spawnY);

                // Instantiate a tomato at the random position
                GameObject newTomato = Instantiate(tomatoPrefab, spawnPosition, Quaternion.identity);

                // Calculate the direction towards the play area
                Vector2 direction = (Vector2.zero - spawnPosition).normalized;

                // Set the initial velocity of the tomato to move towards the play area
                newTomato.GetComponent<Rigidbody2D>().velocity = direction * initialSpeed;

                // Destroy the tomato after its lifetime
                Destroy(newTomato, tomatoLifetime);

                // Update the last spawn time to the current time
                lastSpawnTime = Time.time;
            }

            // Wait for the next iteration
            yield return null;
        }
    }
}

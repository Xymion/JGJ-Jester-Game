using System.Collections;
using UnityEngine;

public class TomatoInitiator : MonoBehaviour
{
  
    public GameObject tomatoPrefab;
    public float tomatoSpeed = 3f;
   

    // Method to spawn a single tomato
    public void SpawnSingleTomato()
    {
        // Determine a random position outside the play area
        Vector3 spawnPosition = GetRandomSpawnPosition();

        // Instantiate the tomato at the random position
        GameObject newTomato = Instantiate(tomatoPrefab, spawnPosition, Quaternion.identity);

        // Calculate the direction towards the center of the play area
        Vector2 direction = (Vector2.zero - (Vector2)newTomato.transform.position).normalized;

        // Set the initial velocity of the tomato to move towards the center of the play area
        newTomato.GetComponent<Rigidbody2D>().velocity = direction * tomatoSpeed;

        StartCoroutine(DestroyTomatoAfterDelay(newTomato, 7f));
    }
    private IEnumerator DestroyTomatoAfterDelay(GameObject tomato, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Check if the tomato still exists before attempting to destroy it
        if (tomato != null)
        {
            DestroyTomato(tomato);
        }
    }

    // Method to destroy a tomato
    public void DestroyTomato(GameObject tomato)
    {
        Destroy(tomato);
    }

    Vector3 GetRandomSpawnPosition()
    {
        float spawnX, spawnY;
        float side = Random.Range(0, 4); // 0: Top, 1: Right, 2: Bottom, 3: Left

        switch (side)
        {
            case 0: // Top
                spawnX = Random.Range(-10f, 10f);
                spawnY = 7f;
                break;
            case 1: // Right
                spawnX = 10f;
                spawnY = Random.Range(-7f, 7f);
                break;
            case 2: // Bottom
                spawnX = Random.Range(-10f, 10f);
                spawnY = -7f;
                break;
            case 3: // Left
                spawnX = -10f;
                spawnY = Random.Range(-7f, 7f);
                break;
            default:
                spawnX = 0f;
                spawnY = 0f;
                break;
        }

        return new Vector3(spawnX, spawnY, 0f);
    }

    

}
using UnityEngine;

public class TomatoThruster : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {
        // Set initial movement direction
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        GetComponent<Rigidbody2D>().velocity = randomDirection * speed;
    }

    void Update()
    {
        // Optionally handle additional behaviors or destruction conditions
    }
}

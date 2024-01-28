using UnityEngine;

public class TomatoThruster : MonoBehaviour
{
    public float lifetime = 10f;

    void Start()
    {
        InvokeRepeating("CheckAndDestroy", lifetime, 0.1f);
    }

    void CheckAndDestroy()
    {
        if (gameObject != null)
        {
            // Perform additional checks if needed
            // ...

            // Destroy the tomato
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        // Stop the repeating check when the object is being destroyed
        CancelInvoke("CheckAndDestroy");
    }
}


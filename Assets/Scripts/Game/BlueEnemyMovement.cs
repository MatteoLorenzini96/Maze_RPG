using UnityEngine;

public class BlueEnemyMovement : MonoBehaviour
{
    private Vector3 initialPosition; 
    public float collisionRadius = 0.5f; 
    void Start()
    {
        initialPosition = transform.position; 
    }

    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, collisionRadius);
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                Destroy(collider.gameObject);
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
                return;
            }
        }
    }

    public void MoveEnemy()
    {
        if (transform.position == initialPosition)
        {
            // Se si trova nella posizione iniziale, muovi il nemico di 1 unità verso l'alto rispetto alla sua posizione attuale
            transform.position += Vector3.up * 1;
            transform.Rotate(180f, 0f, 0f);
        }
        else
        {
            transform.position = initialPosition;
            transform.Rotate(180f, 0f, 0f);
        }
    }
}
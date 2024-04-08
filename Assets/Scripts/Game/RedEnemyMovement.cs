using UnityEngine;

public class RedEnemyMovement : MonoBehaviour
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
            // Se si trova nella posizione iniziale, muovi il nemico di 1 unità a destra rispetto alla sua posizione attuale
            transform.position += Vector3.right * 1;

            Invoke("CallNextTurn", 1f);
        }
        else
        {
            // Se non si trova nella posizione iniziale, riporta il nemico alla posizione iniziale
            transform.position = initialPosition;
        }
    }

    public void ResetPosition()
    {
        transform.position = initialPosition; // Riporta il nemico alla posizione iniziale
    }

    
    private void CallNextTurn()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            // Chiama la funzione NextTurn del GameManager
            gameManager.NextTurn();
        }
        else
        {
            Debug.LogError("GameManager non trovato nella scena.");
        }
    }
}

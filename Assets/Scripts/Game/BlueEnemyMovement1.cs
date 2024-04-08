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
                // Se il player è nel raggio di collisione, distruggilo e ricarica la scena
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

            Invoke("CallNextTurn", 1f);
        }
        else
        {
            transform.position = initialPosition;
        }
    }

    public void ResetPosition()
    {
        transform.position = initialPosition; 
    }

    private void CallNextTurn()
    {
        // Assicurati che il GameManager esista nella scena
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.NextTurn();
        }
        else
        {
            Debug.LogError("GameManager non trovato nella scena.");
        }
    }
}
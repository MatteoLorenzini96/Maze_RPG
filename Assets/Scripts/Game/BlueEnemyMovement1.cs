using UnityEngine;

public class BlueEnemyMovement : MonoBehaviour
{
    private Vector3 initialPosition; // Posizione iniziale del nemico
    public float collisionRadius = 0.5f; // Raggio di collisione per il nemico rosso

    void Start()
    {
        initialPosition = transform.position; // Memorizza la posizione iniziale del nemico
    }

    void Update()
    {
        // Verifica se il player è nel raggio di collisione del nemico rosso
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

        // Aggiornamento del movimento del nemico
    }

    public void MoveEnemy()
    {
        // Verifica se il nemico si trova nella posizione iniziale
        if (transform.position == initialPosition)
        {
            // Se si trova nella posizione iniziale, muovi il nemico di 1 unità verso l'alto rispetto alla sua posizione attuale
            transform.position += Vector3.up * 1;

            // Invoca la funzione NextTurn del GameManager dopo 2 secondi
            Invoke("CallNextTurn", 1f);
        }
        else
        {
            // Se non si trova nella posizione iniziale, riporta il nemico alla posizione iniziale
            transform.position = initialPosition;
        }
    }

    // Metodo per far ritornare il nemico alla posizione iniziale
    public void ResetPosition()
    {
        transform.position = initialPosition; // Riporta il nemico alla posizione iniziale
    }

    // Metodo per chiamare la funzione NextTurn del GameManager
    private void CallNextTurn()
    {
        // Assicurati che il GameManager esista nella scena
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
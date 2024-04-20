using UnityEngine;
using UnityEngine.SceneManagement;

public class RedEnemyMovement : MonoBehaviour
{
    private Vector3 initialPosition;
    public float collisionRadius = 0.5f;
    private PlayerMovement playerMovement; 

    void Start()
    {
        initialPosition = transform.position;
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, collisionRadius);
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                playerMovement.Death();
                Invoke("ReloadScene", 1f);
                return;
            }
        }
    }

    private void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void MoveEnemy()
    {
        if (transform.position == initialPosition)
        {
            // Se si trova nella posizione iniziale, muovi il nemico di 1 unità a destra rispetto alla sua posizione attuale
            transform.position += Vector3.right * 1;
            transform.Rotate(0f, 180f, 0f);
        }
        else
        {
            transform.position = initialPosition;
            transform.Rotate(0f, 180f, 0f);
        }
    }
}

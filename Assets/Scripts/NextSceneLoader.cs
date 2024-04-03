using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLoader : MonoBehaviour
{
    public string nextSceneName; // Il nome della scena successiva che si desidera caricare
    public Collider2D playerCollider; // Il collider del giocatore

    private void Start()
    {
        // Assicurati che il collider del giocatore non sia null
        if (playerCollider == null)
        {
            Debug.LogError("Player collider not assigned in NextSceneLoader.");
        }
    }

    private void Update()
    {
        // Verifica se il collider del giocatore si trova all'interno dell'area
        if (playerCollider.bounds.Contains(transform.position))
        {
            // Carica la scena successiva
            SceneManager.LoadScene(nextSceneName);
        }
    }
}


using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLoader : MonoBehaviour
{
    public string nextSceneName; // Il nome della scena successiva che si desidera caricare

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se il collider che ha causato la collisione è il giocatore
        if (other.CompareTag("Player"))
        {
            // Carica la scena successiva
            SceneManager.LoadScene(nextSceneName);
        }
    }
}


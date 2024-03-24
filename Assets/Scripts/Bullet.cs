using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    // Metodo chiamato quando l'oggetto Bullet entra in collisione con un altro oggetto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Controlla se l'oggetto con cui si è verificata la collisione è il Player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Se sì, distrugge il Player
            Destroy(collision.gameObject);

            // Ricarica la scena dopo un breve ritardo
            Invoke("ReloadScene", 0.5f);
        }
    }

    // Metodo per ricaricare la scena corrente
    private void ReloadScene()
    {
        // Ottiene l'indice della scena corrente
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Ricarica la scena corrente
        SceneManager.LoadScene(currentSceneIndex);
    }
}

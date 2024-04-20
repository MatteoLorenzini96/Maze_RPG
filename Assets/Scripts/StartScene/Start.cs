using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public string nextSceneName;

    public Transform references;
    public void PassaScenaSuccessiva()
    {
        // Controlla se l'oggetto References ha figli al suo interno
        if (references != null && references.childCount == 0)
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("Impossibile passare alla scena successiva: l'oggetto References ha ancora figli al suo interno.");
        }
    }
}
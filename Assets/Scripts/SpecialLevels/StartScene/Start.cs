using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public string nextSceneName;
    public TextMeshProUGUI infoText; // Riferimento all'elemento TextMesh Pro

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
            StartCoroutine(DisplayInfoForSeconds("The Title is not in place", 2f));
        }
    }

    private IEnumerator DisplayInfoForSeconds(string info, float duration)
    {
        infoText.text = info; // Imposta il testo dell'elemento TextMesh Pro
        infoText.gameObject.SetActive(true); // Attiva l'elemento TextMesh Pro

        yield return new WaitForSeconds(duration);

        infoText.gameObject.SetActive(false); // Disattiva l'elemento TextMesh Pro dopo 'duration' secondi
    }
}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlinkingObjects : MonoBehaviour
{
    public GameObject[] objectsToBlink; // Array contenente gli oggetti da far lampeggiare
    private Color[] initialColors; // Colori iniziali degli oggetti
    public float blinkDuration = 2f; // Durata del lampeggio
    public float blinkInterval = 0.5f; // Intervallo tra un lampeggio e l'altro

    private Coroutine blinkCoroutine;

    void Start()
    {
        // Ottiene i colori iniziali degli oggetti
        initialColors = new Color[objectsToBlink.Length];
        for (int i = 0; i < objectsToBlink.Length; i++)
        {
            Image image = objectsToBlink[i].GetComponent<Image>();
            if (image != null)
            {
                initialColors[i] = image.color;
            }
            else
            {
                Debug.LogWarning("Nessun componente Image trovato su: " + objectsToBlink[i].name);
            }
        }

        // Avvia il coroutine per far lampeggiare gli oggetti
        blinkCoroutine = StartCoroutine(BlinkObjects());
    }

    IEnumerator BlinkObjects()
    {
        while (true) // Ripeti all'infinito
        {
            foreach (GameObject obj in objectsToBlink)
            {
                // Ottiene il componente Image
                Image image = obj.GetComponent<Image>();
                if (image != null)
                {
                    // Cambia il colore dell'immagine in giallo
                    image.color = Color.yellow;
                    yield return new WaitForSeconds(blinkInterval);

                    // Riporta il colore originale dell'immagine
                    int index = System.Array.IndexOf(objectsToBlink, obj);
                    image.color = initialColors[index];
                    yield return new WaitForSeconds(blinkInterval);
                }
                else
                {
                    Debug.LogWarning("Nessun componente Image trovato su: " + obj.name);
                }
            }
            // Aspetta per il prossimo ciclo di lampeggio
            yield return new WaitForSeconds(blinkDuration);
        }
    }

    void OnDestroy()
    {
        // Ferma il coroutine quando lo script viene distrutto
        if (blinkCoroutine != null)
            StopCoroutine(blinkCoroutine);
    }
}

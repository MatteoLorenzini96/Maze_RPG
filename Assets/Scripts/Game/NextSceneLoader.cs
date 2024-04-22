using UnityEngine;
using UnityEngine.UI;

public class NextSceneLoader : MonoBehaviour
{
    public GameObject oggettoDaAttivare; // Oggetto da attivare al raggiungimento del player
    public Collider2D playerCollider;
    public ContaMovimenti contaMovimenti; // Riferimento al componente ContaMovimenti per interrompere il calcolo dei movimenti
    public PlayerMovement playerMovement; // Riferimento al componente di movimento del player

    public Button PassButton;

    public GameObject winEffect;

    private void Start()
    {
        if (playerCollider == null)
        {
            Debug.LogError("Player collider not assigned in NextSceneLoader.");
        }
        if (contaMovimenti == null)
        {
            Debug.LogError("ContaMovimenti not assigned in NextSceneLoader.");
        }
        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement not assigned in NextSceneLoader.");
        }
    }

    private void Update()
    {
        if (playerCollider != null && playerCollider.isActiveAndEnabled && playerCollider.bounds.Contains(transform.position))
        {
            // Attiva l'oggetto
            if (oggettoDaAttivare != null)
            {
                PassButton.gameObject.SetActive(false);
                oggettoDaAttivare.SetActive(true);
            }

            // Interrompi il calcolo dei movimenti
            if (contaMovimenti != null)
            {
                contaMovimenti.enabled = false;
            }

            // Disabilita il movimento del player
            if (playerMovement != null)
            {
                playerMovement.enabled = false;
            }

            if (winEffect != null)
            {
                // Crea un oggetto vuoto come genitore dell'effetto di distruzione
                GameObject effectsParent = new GameObject("EffectsParent");

                // Istanzia l'effetto di distruzione come figlio dell'oggetto vuoto appena creato
                Instantiate(winEffect, transform.position, Quaternion.identity, effectsParent.transform);

                // Distruggi l'oggetto vuoto (e tutti i suoi figli, incluso l'effetto di distruzione) dopo un certo periodo di tempo
                Destroy(effectsParent, 1f); // Modifica il tempo di distruzione se necessario
            }
            // Disattiva questo script
            enabled = false;
        }
    }
}

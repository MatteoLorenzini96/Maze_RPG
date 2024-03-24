using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private bool isMoving = false; // Flag per indicare se il giocatore sta muovendo

    // Metodo per avviare il movimento del giocatore
    public void StartMovement()
    {
        if (!isMoving)
        {
            isMoving = true;
            // Aggiungi qui la logica per far muovere il giocatore
            Debug.Log("Il giocatore si sta muovendo.");
            // Ad esempio, puoi usare la funzione MoveTo() per far muovere il giocatore
            MoveTo(new Vector3(1, 0, 0)); // Esempio di movimento verso destra
        }
    }

    // Metodo per controllare se il giocatore ha finito di muoversi
    public bool HasFinishedMovement()
    {
        // In un'implementazione reale, questo metodo dovrebbe controllare se il giocatore ha completato il suo movimento
        // Ad esempio, se il giocatore ha raggiunto la destinazione o ha finito il suo movimento in base a qualche altra logica di gioco
        // In questo esempio di base, assumiamo che il giocatore finisca il movimento dopo un certo periodo di tempo
        return !isMoving;
    }

    // Metodo per muovere il giocatore verso una posizione specifica
    private void MoveTo(Vector3 targetPosition)
    {
        // Implementa qui la logica per far muovere il giocatore verso la posizione target
        // Ad esempio, puoi usare la funzione Translate per spostare il giocatore
        // In questo esempio di base, facciamo solo un movimento simulato per un breve periodo di tempo
        StartCoroutine(SimulateMovement(targetPosition));
    }

    // Coroutine per simulare il movimento del giocatore
    private IEnumerator SimulateMovement(Vector3 targetPosition)
    {
        float moveSpeed = 5f; // Velocità di movimento del giocatore

        // Calcola la distanza da percorrere
        float distance = Vector3.Distance(transform.position, targetPosition);

        // Calcola il tempo necessario per raggiungere la destinazione
        float duration = distance / moveSpeed;

        // Muovi il giocatore verso la posizione target nel tempo specificato
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Assicurati che il giocatore sia esattamente alla posizione target alla fine del movimento
        transform.position = targetPosition;

        // Imposta il flag di movimento a falso per indicare che il movimento è terminato
        isMoving = false;
    }
}

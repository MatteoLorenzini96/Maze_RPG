using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager2 : MonoBehaviour
{
    public enum GameState { Planning, Movement }
    public GameState currentState;

    public Button passButton;
    public Button endPlanningButton;

    // Lista dei giocatori che possono muoversi durante la fase di Planning
    public List<PlayerController> Planning = new List<PlayerController>();

    // Lista dei giocatori che devono muoversi durante la fase di Movimento
    public List<PlayerController> Movimento = new List<PlayerController>();

    private int currentMovementIndex = 0; // Indice per tenere traccia del giocatore corrente durante la fase di Movimento

    private void Start()
    {
        currentState = GameState.Planning;
        passButton.interactable = false;
        endPlanningButton.interactable = true;
    }

    public void EndPlanningPhase()
    {
        currentState = GameState.Movement;
        passButton.interactable = false;
        endPlanningButton.interactable = false;

        // Inizia la fase di Movimento
        StartCoroutine(ExecuteMovementPhase());
    }

    // Coroutine per eseguire la fase di Movimento
    private IEnumerator ExecuteMovementPhase()
    {
        // Itera attraverso tutti i giocatori e fai muovere ciascuno di essi
        foreach (PlayerController player in Movimento)
        {
            player.StartMovement(); // Avvia il movimento del giocatore
            yield return new WaitUntil(() => player.HasFinishedMovement()); // Aspetta fino a quando il giocatore ha finito di muoversi
        }

        // Resetta l'indice per il prossimo turno di movimento
        currentMovementIndex = 0;

        // Torna alla fase di Planning
        currentState = GameState.Planning;
        passButton.interactable = false;
        endPlanningButton.interactable = true;
    }

    public void PassTurn()
    {
        if (currentState == GameState.Planning)
        {
            // Logica per terminare la fase di Planning
            // Qui puoi aggiungere il codice per passare il turno al prossimo giocatore
            // e/o passare alla fase di Movimento
            currentState = GameState.Movement;
            passButton.interactable = true;
            endPlanningButton.interactable = false;
        }
    }
}

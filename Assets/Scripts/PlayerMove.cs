using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public float moveDistance = 1f; // Distanza di movimento del player
    
    private Stack<Vector3> previousPositions = new Stack<Vector3>(); // Stack per tenere traccia delle posizioni precedenti
   
    private int movesRemaining = 3; // Numero di movimenti rimanenti per il turno

    public GameManager gameManager;

    void Update()
    {
        if (gameManager.currentTurn == GameManager.Turn.Player)
        {
            // Gestiamo il movimento del player quando un tasto viene premuto
            if (Input.GetKeyDown(KeyCode.W))
            {
                TryMovePlayer(Vector3.up);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                TryMovePlayer(Vector3.left);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                TryMovePlayer(Vector3.down);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                TryMovePlayer(Vector3.right);
            }
            else if (Input.GetKeyDown(KeyCode.Z)) // Tasto per annullare l'ultima mossa
            {
                UndoLastMove();
            }
        }
    }

    // Funzione per tentare di muovere il player nella direzione specificata
    void TryMovePlayer(Vector3 direction)
    {
        // Controlla se ci sono ancora movimenti rimanenti
        if (movesRemaining > 0)
        {
            // Calcola la nuova posizione
            Vector3 newPosition = transform.position + direction * moveDistance;

            // Controlla se ci sono collisioni nella nuova posizione
            Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, 0.1f);
            bool canMove = true;
            foreach (var collider in colliders)
            {
                // Se la nuova posizione è occupata, il player non può muoversi
                if (collider.gameObject != gameObject)
                {
                    canMove = false;
                    break;
                }
            }

            // Se il player può muoversi, esegui il movimento
            if (canMove)
            {
                // Salva la posizione corrente del player prima di spostarlo
                previousPositions.Push(transform.position);

                // Sposta il player nella nuova posizione
                transform.position = newPosition;

                // Riduce il numero di movimenti rimanenti
                movesRemaining--;
            }
        }
    }

    // Funzione per annullare l'ultima mossa del player
    void UndoLastMove()
    {
        // Controlla se ci sono mosse precedenti da annullare
        if (previousPositions.Count > 0)
        {
            // Ripristina la posizione precedente del player
            transform.position = previousPositions.Pop();

            // Ripristina il numero di movimenti rimanenti
            movesRemaining++;
        }
    }
    public void ResetMoves()
    {
        movesRemaining = 3; // Resetta il numero di movimenti rimanenti
        previousPositions.Clear();
    }
}


using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class PlayerMovement : MonoBehaviour
{
    public float moveDistance = 1f; 

    private GameManager gameManager;
    private int movesRemaining = 3; 
    private Stack<Vector3> previousPositions = new Stack<Vector3>(); // Stack per tenere traccia delle posizioni precedenti

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        // Controlla se è il turno del giocatore nel GameManager
        if (gameManager.currentTurn == Turn.Player)
        {
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
            else if (Input.GetKeyDown(KeyCode.Z)) 
            {
                UndoLastMove();
            }
        }
    }

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
                if (collider.gameObject != gameObject)
                {
                    canMove = false;
                    break;
                }
            }

            if (canMove)
            {
                previousPositions.Push(transform.position);

                // Sposta il player nella nuova posizione
                transform.position = newPosition;

                // Riduce il numero di movimenti rimanenti
                movesRemaining--;
            }
        }
    }

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
        movesRemaining = 3;
        previousPositions.Clear();
    }
}

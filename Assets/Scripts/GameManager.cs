using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Turn { None, Player, EnemyRed, EnemyBlue, Crossbow, Planning };

public class GameManager : MonoBehaviour
{
    public Turn currentTurn = Turn.Player;

    public PlayerMovement playerMovement;
    public RedEnemyMovement enemyRedMovement;
    public BlueEnemyMovement enemyBlueMovement;
    public Crossbow crossbow;

    [SerializeField] private List<Turn> turns = new List<Turn>();
    [SerializeField] private int actualTurnIndex;

    public Button SaveOrderButton; // Riferimento al bottone 
    public Button PassButton; // Riferimento al bottone 

    public void NextTurn()
    {
        SaveOrderButton.interactable = false; // Disabilita il bottone
        currentTurn = turns[actualTurnIndex];
        switch (currentTurn)
        {
            case Turn.EnemyRed:
                Debug.Log("È il turno del nemico rosso.");
                enemyRedMovement.MoveEnemy();
                break;
            case Turn.EnemyBlue:
                Debug.Log("È il turno del nemico blu.");
                enemyBlueMovement.MoveEnemy();
                break;
            case Turn.Crossbow:
                Debug.Log("È il turno della Crossbow.");
                crossbow.Shoot();
                break;
            case Turn.Player:
                Debug.Log("È il turno del giocatore.");
                break;
            case Turn.Planning:
                StartPlanning();
                EnableDragDropScripts();
                return;
            default:
                break;
        }

        actualTurnIndex++;
        if (actualTurnIndex >= turns.Count)
        {
            turns.Add(Turn.Planning);
        }

        playerMovement.ResetMoves();

        DisableDragDropScripts();
    }

    private void DisableDragDropScripts()
    {
        DragDrop[] dragDropItems = FindObjectsOfType<DragDrop>();
        foreach (DragDrop item in dragDropItems)
        {
            item.enabled = false;
        }
    }

    private void EnableDragDropScripts()
    {
        DragDrop[] dragDropItems = FindObjectsOfType<DragDrop>();
        foreach (DragDrop item in dragDropItems)
        {
            item.enabled = true;
        }
    }

    public void StartPlanning()
    {
        DragDrop[] dragDropItems = FindObjectsOfType<DragDrop>();
        foreach (DragDrop item in dragDropItems)
        {
            item.ResetPosition();
        }

        actualTurnIndex = 0;
        currentTurn = Turn.None;
        turns.Clear();
        SaveOrderButton.interactable = true; // Abilita il bottone 
        PassButton.interactable = false; // Abilita il bottone
    }

    private void Start()
    {
        StartPlanning();
    }

    public void SetTurns(List<Turn> newTurns)
    {
        turns = newTurns;

        actualTurnIndex = 0;
    }

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject gameManagerObject = new GameObject("GameManager");
                    _instance = gameManagerObject.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }
}

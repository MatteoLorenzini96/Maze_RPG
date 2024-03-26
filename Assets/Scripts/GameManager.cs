using System.Collections.Generic;
using UnityEngine;

public enum Turn { None, Player, EnemyRed, EnemyBlue, Crossbow };

public class GameManager : MonoBehaviour
{
    
    public Turn currentTurn = Turn.Player; // Turno attuale

    public PlayerMovement playerMovement; // Riferimento allo script del movimento del player
    public RedEnemyMovement enemyRedMovement; // Riferimento allo script del movimento del nemico rosso
    public BlueEnemyMovement enemyBlueMovement; // Riferimento allo script del movimento del nemico blu
    public Crossbow Crossbow; // Riferimento allo script della Crossbow

   [SerializeField] private List<Turn> turns = new List<Turn>();

   [SerializeField] private int actualTurnIndex;

    // Metodo per passare al turno successivo
    public void NextTurn()
    {
        currentTurn = turns[actualTurnIndex];
        switch (currentTurn)
        {
            case Turn.EnemyRed:
                //currentTurn = Turn.EnemyRed; // Passa al turno del nemico rosso
                Debug.Log("È il turno del nemico rosso.");
                enemyRedMovement.MoveEnemy(); // Movimento nemico rosso
                break;
            case Turn.EnemyBlue:
                //currentTurn = Turn.EnemyBlue; // Passa al turno del nemico blu
                Debug.Log("È il turno del nemico blu.");
                enemyBlueMovement.MoveEnemy(); // Movimento nemico blu
                break;
            case Turn.Crossbow:
                //currentTurn = Turn.Crossbow; // Passa al turno della Crossbow
                Debug.Log("È il turno della Crossbow.");
                Crossbow.Shoot();
                // Implementa qui il movimento della Crossbow
                break;
            case Turn.Player:
                //currentTurn = Turn.Player; // Passa al turno del player
                Debug.Log("È il turno del giocatore.");
                break;
            default:
                break;
        }

        actualTurnIndex++;
        if (actualTurnIndex >= turns.Count)
        {
            Debug.Log("Da qua riparte il planning");
        }

        // Resetta i movimenti del player per il nuovo turno
        playerMovement.ResetMoves();
    }


    void Update()
    {
        // Controlla se il tasto per passare al turno successivo è stato premuto
        if (Input.GetKeyDown(KeyCode.Space)) // Puoi cambiare KeyCode a tuo piacimento
        {
            NextTurn();
        }
    }

   public void SetTurns(List<Turn> newTurns)
    {
        turns = newTurns;

        actualTurnIndex = 0;
    }

    // Implementa il singleton pattern per GameManager
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

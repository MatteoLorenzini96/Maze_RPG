using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Turn { Player, EnemyRed, EnemyBlue }; // Enum per i turni del gioco
    public Turn currentTurn = Turn.Player; // Turno attuale

    public PlayerMovement playerMovement; // Riferimento allo script del movimento del player
    public RedEnemyMovement enemyRedMovement; // Riferimento allo script del movimento del nemico rosso
    public BlueEnemyMovement enemyBlueMovement; // Riferimento allo script del movimento del nemico blu

    // Metodo per passare al turno successivo
    public void NextTurn()
    {
        switch (currentTurn)
        {
            case Turn.Player:
                currentTurn = Turn.EnemyRed; // Passa al turno del nemico rosso
                Debug.Log("È il turno del nemico rosso.");
                enemyRedMovement.MoveEnemy(); // Movimento nemico rosso
                break;
            case Turn.EnemyRed:
                currentTurn = Turn.EnemyBlue; // Passa al turno del nemico blu
                Debug.Log("È il turno del nemico blu.");
                enemyBlueMovement.MoveEnemy(); // Movimento nemico blu
                break;
            case Turn.EnemyBlue:
                currentTurn = Turn.Player; // Passa al turno del player
                Debug.Log("È il turno del player.");
                break;
            default:
                break;
        }

        // Resetta i movimenti del player per il nuovo turno
        playerMovement.ResetMoves();
    }

    void Update()
    {
        // Controlla se il tasto per passare al turno successivo è stato premuto
        if (Input.GetKeyDown(KeyCode.Space)) // Puoi cambiare KeyCode a tuo piacimento
        {
            NextTurn(); // Chiama il metodo NextTurn() quando il tasto è premuto
        }
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

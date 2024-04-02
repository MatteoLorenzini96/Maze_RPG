using UnityEngine;
using UnityEngine.UI;

public class GameStatusLabel : MonoBehaviour
{
    private Text statusText;

    private void Start()
    {
        statusText = GetComponent<Text>();
    }

    private void Update()
    {
        // Ottieni il GameManager
        GameManager gameManager = GameManager.Instance;

        // Controlla lo stato del gioco e aggiorna il testo di conseguenza
        switch (gameManager.currentTurn)
        {
            case Turn.None:
                statusText.text = "Fase di planning";
                break;
            case Turn.Player:
                statusText.text = "Turno del giocatore";
                break;
            case Turn.EnemyRed:
                statusText.text = "Turno del rosso";
                break;
            case Turn.EnemyBlue:
                statusText.text = "Turno del blu";
                break;
            case Turn.Crossbow:
                statusText.text = "Turno della balestra";
                break;
            default:
                statusText.text = "Stato non valido";
                break;
        }
    }
}

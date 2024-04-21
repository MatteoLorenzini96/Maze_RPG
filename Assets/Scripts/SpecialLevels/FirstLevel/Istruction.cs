using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Istruction : MonoBehaviour
{
    public TextMeshProUGUI playerTurnText;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance; // Ottieni l'istanza del GameManager
        playerTurnText.gameObject.SetActive(false); // Assicurati che il testo sia disattivato all'inizio
    }

    private void Update()
    {
        if (gameManager.currentTurn == Turn.Player)
        {
            playerTurnText.gameObject.SetActive(true); // Attiva il testo quando è il turno del giocatore
        }
        else
        {
            playerTurnText.gameObject.SetActive(false); // Disattiva il testo quando non è il turno del giocatore
        }
    }
}

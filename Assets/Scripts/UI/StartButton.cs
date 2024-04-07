using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
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
                statusText.text = "Start";
                break;
            case Turn.Player:
                statusText.text = "Next";
                break;
            case Turn.EnemyRed:
                statusText.text = "Next";
                break;
            case Turn.EnemyBlue:
                statusText.text = "Next";
                break;
            case Turn.Crossbow:
                statusText.text = "Next";
                break;
            default:
                statusText.text = "Stato non valido";
                break;
        }
    }
}

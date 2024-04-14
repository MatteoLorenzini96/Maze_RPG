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
        GameManager gameManager = GameManager.Instance;

        // Controlla lo stato del gioco e aggiorna il testo di conseguenza
        switch (gameManager.currentTurn)
        {
            case Turn.None:
                statusText.text = "Drag UI";
                break;
            case Turn.Player:
                statusText.text = "Player Turn";
                break;
            case Turn.EnemyRed:
                statusText.text = "Red Turn";
                break;
            case Turn.EnemyBlue:
                statusText.text = "Blue Turn";
                break;
            case Turn.Crossbow:
                statusText.text = "Crossbow Turn";
                break;
            default:
                statusText.text = "Invalid text";
                break;
        }
    }
}

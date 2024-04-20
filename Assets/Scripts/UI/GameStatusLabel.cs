using UnityEngine;
using UnityEngine.UI;

public class GameStatusLabel : MonoBehaviour
{
    private Text statusTextMeshPro;

    private void Start()
    {
        statusTextMeshPro = GetComponent<Text>();
    }

    private void Update()
    {
        GameManager gameManager = GameManager.Instance;

        // Controlla lo stato del gioco e aggiorna il testo di conseguenza
        switch (gameManager.currentTurn)
        {
            case Turn.None:
                statusTextMeshPro.text = "Drag UI";
                break;
            case Turn.Player:
                statusTextMeshPro.text = "Player Turn";
                break;
            case Turn.EnemyRed:
                statusTextMeshPro.text = "Hor-Trap Turn";
                break;
            case Turn.EnemyBlue:
                statusTextMeshPro.text = "Ver-Trap Turn";
                break;
            case Turn.Crossbow:
                statusTextMeshPro.text = "Crossbow Turn";
                break;
            default:
                statusTextMeshPro.text = "Invalid text";
                break;
        }
    }
}

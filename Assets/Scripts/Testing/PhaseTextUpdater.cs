using UnityEngine;
using UnityEngine.UI;

public class PhaseTextUpdater : MonoBehaviour
{
    public Text phaseText;
    public GameManager2 gameManager;

    private void Start()
    {
        UpdatePhaseText();
    }

    private void UpdatePhaseText()
    {
        if (gameManager.currentState == GameManager2.GameState.Planning)
        {
            phaseText.text = "Planning Phase";
        }
        else if (gameManager.currentState == GameManager2.GameState.Movement)
        {
            phaseText.text = "Movement Phase";
        }
    }

    // Aggiornare il testo ogni volta che lo stato del GameManager2 cambia
    private void Update()
    {
        UpdatePhaseText();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemSlotHandler : MonoBehaviour
{
    public UnityEngine.UI.Button PassButton;
    public UnityEngine.UI.Button SaveOrderButton;
    public TextMeshProUGUI infoText; // Riferimento all'elemento TextMesh Pro

    public List<ItemSlot> slots;
    public Transform references;

    public void EndPlanning()
    {
        if (references.childCount == 0)
        {
            GameManager.Instance.SetTurns(GetTurnIdentities());
            PassButton.interactable = true;
            SaveOrderButton.interactable = false;
        }
        else
        {
            Debug.LogWarning("Cannot end planning: References object still has child objects.");
            StartCoroutine(DisplayInfoForSeconds("All elements must have an assigned turn", 2f));
        }
    }

    private List<Turn> GetTurnIdentities()
    {
        List<Turn> turns = new List<Turn>();

        foreach (ItemSlot slot in slots)
        {
            var turn = slot.GetTurnIdentity();
            turns.Add(turn);
        }

        return turns;
    }

    private IEnumerator DisplayInfoForSeconds(string info, float duration)
    {
        infoText.text = info; // Imposta il testo dell'elemento TextMesh Pro
        infoText.gameObject.SetActive(true); // Attiva l'elemento TextMesh Pro

        yield return new WaitForSeconds(duration);

        infoText.gameObject.SetActive(false); // Disattiva l'elemento TextMesh Pro dopo 'duration' secondi
    }
}
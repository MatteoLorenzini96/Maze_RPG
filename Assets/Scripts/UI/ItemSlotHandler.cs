using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotHandler : MonoBehaviour
{
    public UnityEngine.UI.Button PassButton;
    public UnityEngine.UI.Button SaveOrderButton;

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
}

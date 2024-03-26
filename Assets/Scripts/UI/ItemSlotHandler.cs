using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotHandler : MonoBehaviour
{
    public List<ItemSlot> slots;
    public void EndPlanning()
    {
        GameManager.Instance.SetTurns(GetTurnIdentities());
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


using UnityEngine;
using System.Collections.Generic;

public class SlotTurnOrderManager : MonoBehaviour
{
    public RectTransform[] itemSlots; // Array degli slot degli oggetti

    public List<TurnObject> GetTurnOrder()
    {
        // Lista per tenere traccia degli oggetti UI ordinati per posizione negli slot
        List<TurnObject> orderedTurnObjects = new List<TurnObject>();

        // Scandisci tutti gli slot degli oggetti
        foreach (RectTransform slot in itemSlots)
        {
            // Scandisci tutti gli oggetti UI all'interno dello slot
            foreach (Transform child in slot)
            {
                // Ottieni il componente TurnObject dall'oggetto UI
                TurnObject turnObject = child.GetComponent<TurnObject>();

                // Se l'oggetto ha un componente TurnObject, aggiungilo alla lista ordinata
                if (turnObject != null)
                {
                    orderedTurnObjects.Add(turnObject);
                }
            }
        }

        // Ordina la lista degli oggetti UI in base alla loro posizione negli slot
        orderedTurnObjects.Sort((a, b) =>
        {
            int slotIndexA = GetSlotIndex(a.transform.parent as RectTransform);
            int slotIndexB = GetSlotIndex(b.transform.parent as RectTransform);
            return slotIndexA.CompareTo(slotIndexB);
        });

        return orderedTurnObjects;
    }

    private int GetSlotIndex(RectTransform slot)
    {
        // Ottieni l'indice dello slot all'interno dell'array
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i] == slot)
            {
                return i;
            }
        }
        return -1;
    }
}

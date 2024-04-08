using UnityEngine.EventSystems;
using UnityEngine;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public int turnOrder;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }

    public Turn GetTurnIdentity()
    {
        var urn = GetComponentInChildren<TurnIdentity>();

        if (urn != null)
        {
            return urn.turnIdentity;
        }

        return Turn.None;
    }
}

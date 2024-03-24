using UnityEngine.EventSystems;
using UnityEngine;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public int turnOrder; // Ordine della risoluzione dei turni

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }
}

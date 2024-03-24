using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private RectTransform itemSlot;
    [SerializeField] private GameObject referenceParent; // GameObject di riferimento

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;
    private Transform originalParent; // Memorizza il parente originale
    private Transform lastDroppedItem; // Memorizza l'ultimo elemento rilasciato

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = rectTransform.localPosition; // Memorizza la posizione locale iniziale
        originalParent = transform.parent; // Memorizza il parente originale
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        // Ottieni l'ItemSlot su cui è stato rilasciato l'elemento
        RectTransform slotRectTransform = FindSlotUnderMouse(eventData.position);

        if (slotRectTransform != null)
        {
            // Se lo slot è già occupato, ripristina il vecchio elemento
            if (slotRectTransform.childCount > 0)
            {
                lastDroppedItem = slotRectTransform.GetChild(0);
                lastDroppedItem.SetParent(originalParent, false); // Ripristina il parentesco al parente originale
                lastDroppedItem.localPosition = originalPosition; // Usa la posizione locale originale
            }

            // Imposta il parentesco dell'elemento allo slot
            rectTransform.SetParent(slotRectTransform, false); // Mantieni la scala dell'elemento

            // Posiziona l'elemento al centro dello slot
            rectTransform.anchoredPosition = Vector2.zero;
        }
        else
        {
            // Se non è stato trovato alcuno slot, ritorna all'origine e torna al parente originale
            rectTransform.SetParent(originalParent, false); // Ripristina il parentesco al parente originale
            rectTransform.localPosition = originalPosition; // Usa la posizione locale originale
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Non è necessario memorizzare la posizione iniziale qui
    }

    private RectTransform FindSlotUnderMouse(Vector2 mousePosition)
    {
        // Ottieni tutti gli item slot attivi nel canvas
        ItemSlot[] itemSlots = canvas.GetComponentsInChildren<ItemSlot>();

        // Cerca gli item slot sotto il punto del mouse
        foreach (ItemSlot itemSlot in itemSlots)
        {
            RectTransform slotRectTransform = itemSlot.GetComponent<RectTransform>();
            if (RectTransformUtility.RectangleContainsScreenPoint(slotRectTransform, mousePosition))
            {
                // Se l'elemento è stato rilasciato sopra questo slot, restituisci il RectTransform dello slot
                return slotRectTransform;
            }
        }

        // Se non è stato trovato alcuno slot, restituisci null
        return null;
    }
}
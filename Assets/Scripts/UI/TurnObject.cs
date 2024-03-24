using UnityEngine;

public class TurnObject : MonoBehaviour
{
    public GameObject targetObject; // Riferimento all'oggetto a cui assegnare il turno

    private void Start()
    {
        if (targetObject == null)
        {
            Debug.LogError("Nessun oggetto target assegnato a TurnObject.");
        }
    }

    public void StartTurn()
    {
        if (targetObject != null)
        {
            // Esegui qui le azioni da eseguire quando è il turno dell'oggetto target
            Debug.Log("È il turno dell'oggetto " + targetObject.name);
        }
        else
        {
            Debug.LogError("Nessun oggetto target assegnato a TurnObject.");
        }
    }
}

using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    private static EffectsManager instance;

    private void Awake()
    {
        // Assicurati che esista una sola istanza di EffectsManager in tutto il gioco
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DestroyEffect(GameObject effect)
    {
        Destroy(effect);
    }
}

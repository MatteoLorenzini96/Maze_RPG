using UnityEngine;
using TMPro;

public class ModificaTestoStelle : MonoBehaviour
{
    public ContaMovimenti contaMovimenti; 

    private TextMeshProUGUI testoTMPro; 
    void Start()
    {
        testoTMPro = GetComponent<TextMeshProUGUI>();
        if (contaMovimenti == null)
        {
            Debug.LogError("Riferimento a ContaMovimenti non assegnato!");
        }
    }

    void Update()
    {
        int punteggio = contaMovimenti.CalcolaPunteggio();

        switch (punteggio)
        {
            case 0:
                testoTMPro.text = "Skill Issue";
                break;
            case 1:
                testoTMPro.text = "EZ";
                break;
            case 2:
                testoTMPro.text = "GJ";
                break;
            case 3:
                testoTMPro.text = "Perfect!";
                break;
            default:
                testoTMPro.text = "Errore nel calcolo del punteggio";
                break;
        }
    }
}
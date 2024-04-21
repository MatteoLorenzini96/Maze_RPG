using UnityEngine;
using TMPro; // Importa il namespace TextMeshPro

public class ContaMovimenti : MonoBehaviour
{
    public int numeroMinimoMovimenti = 10; // Numero minimo di movimenti per ottenere 3 stelle
    public GameObject[] stelle; // Array di GameObject rappresentanti le stelle
    public TextMeshProUGUI testoTMPro; // Riferimento al componente TextMeshPro
    

    private int numeroTotaleMovimenti = 0; // Numero totale di movimenti del player

    // Funzione per aggiornare il conteggio dei movimenti
    public void AggiornaMovimenti(int deltaMovimenti = 1)
    {
        numeroTotaleMovimenti += deltaMovimenti;

        // Calcola il punteggio e attiva gli sprite corrispondenti
        int punteggio = CalcolaPunteggio();
        AttivaStelle(punteggio);

        // Attiva il testo TextMeshPro
        testoTMPro.gameObject.SetActive(true);
    }

    // Funzione per calcolare il punteggio in base al numero di movimenti
    public int CalcolaPunteggio()
    {
        float percentualeSopraminimo = ((float)numeroTotaleMovimenti - numeroMinimoMovimenti) / numeroMinimoMovimenti * 100;

        if (percentualeSopraminimo <= 0)
        {
            return 3; // 3 stelle
        }
        else if (percentualeSopraminimo <= 33)
        {
            return 2; // 2 stelle
        }
        else if (percentualeSopraminimo <= 66)
        {
            return 1; // 1 stella
        }
        else
        {
            return 0; // 0 stelle
        }
    }

    // Funzione per attivare gli sprite delle stelle in base al punteggio
    private void AttivaStelle(int punteggio)
    {
        // Disattiva tutte le stelle
        for (int i = 0; i < stelle.Length; i++)
        {
            stelle[i].SetActive(false);
        }

        // Attiva le stelle corrispondenti al punteggio
        for (int i = 0; i < punteggio; i++)
        {
            stelle[i].SetActive(true);
        }
    }
}

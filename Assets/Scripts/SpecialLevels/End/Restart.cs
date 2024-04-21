using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        // Carica la prima scena nell'ordine di build
        SceneManager.LoadScene(0);
    }
}

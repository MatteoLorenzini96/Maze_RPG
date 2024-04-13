using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public void PassaScenaSuccessiva()
    {
        int indiceScenaCorrente = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(indiceScenaCorrente + 1);
    }
}
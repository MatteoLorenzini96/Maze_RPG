using UnityEngine;

public class Crossbow : MonoBehaviour
{
    public float bulletSpeed = 5f; // Velocità del proiettile
    public GameObject bulletPrefab; // Prefab del proiettile
    public float bulletLifetime = 3f; // Durata di vita del proiettile
    public Transform muzzle; // Punto di spawn del proiettile

    private GameObject currentBullet; // Riferimento al proiettile attuale

    public void Shoot()
    {
        if (muzzle == null)
        {
            Debug.LogError("Muzzle transform not assigned!");
            return;
        }

        currentBullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation); // Crea il proiettile
        Rigidbody2D rb = currentBullet.GetComponent<Rigidbody2D>();
        rb.velocity = muzzle.right.normalized * bulletSpeed; // Imposta la velocità del proiettile in linea retta
        Destroy(currentBullet, bulletLifetime); // Cancella il proiettile dopo il tempo specificato

        // Invoca la funzione NextTurn del GameManager dopo 2 secondi
        Invoke("CallNextTurn", 1f);
    }

    // Metodo per chiamare la funzione NextTurn del GameManager
    private void CallNextTurn()
    {
        // Assicurati che il GameManager esista nella scena
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            // Chiama la funzione NextTurn del GameManager
            gameManager.NextTurn();
        }
        else
        {
            Debug.LogError("GameManager non trovato nella scena.");
        }
    }
}
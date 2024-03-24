using UnityEngine;

public class Crossbow : MonoBehaviour
{
    public float bulletSpeed = 5f; // Velocità del proiettile
    public GameObject bulletPrefab; // Prefab del proiettile
    public float bulletLifetime = 3f; // Durata di vita del proiettile
    private GameObject currentBullet; // Riferimento al proiettile attuale

    public void Shoot()
    {
        currentBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity); // Crea il proiettile
        Rigidbody2D rb = currentBullet.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right.normalized * bulletSpeed; // Imposta la velocità del proiettile in linea retta
        Destroy(currentBullet, bulletLifetime); // Cancella il proiettile dopo il tempo specificato
    }
}

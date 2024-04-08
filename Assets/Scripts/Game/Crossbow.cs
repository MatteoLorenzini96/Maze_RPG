using UnityEngine;

public class Crossbow : MonoBehaviour
{
    public float bulletSpeed = 5f; 
    public GameObject bulletPrefab; 
    public float bulletLifetime = 3f; 
    public Transform muzzle; 

    private GameObject currentBullet; 

    public void Shoot()
    {
        if (muzzle == null)
        {
            Debug.LogError("Muzzle transform not assigned!");
            return;
        }

        currentBullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation); 
        Rigidbody2D rb = currentBullet.GetComponent<Rigidbody2D>();
        rb.velocity = muzzle.right.normalized * bulletSpeed; 
        Destroy(currentBullet, bulletLifetime); 

        //Invoke("CallNextTurn", 1f);
    }

    private void CallNextTurn()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.NextTurn();
        }
        else
        {
            Debug.LogError("GameManager non trovato nella scena.");
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLoader : MonoBehaviour
{
    public string nextSceneName; 
    public Collider2D playerCollider; 
    private void Start()
    {
        if (playerCollider == null)
        {
            Debug.LogError("Player collider not assigned in NextSceneLoader.");
        }
    }

    private void Update()
    {
        if (playerCollider != null && playerCollider.isActiveAndEnabled && playerCollider.bounds.Contains(transform.position))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

}
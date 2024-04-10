using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    //Falling and respawning
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.transform.CompareTag("Player"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (collider.transform.CompareTag("Box"))
            Destroy(GameObject.FindGameObjectWithTag("Box"));
    }
}

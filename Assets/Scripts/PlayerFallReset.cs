using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFallReset : MonoBehaviour
{
    public float fallThreshold = -10f;  // Adjust this to match your level's bottom.

    private void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

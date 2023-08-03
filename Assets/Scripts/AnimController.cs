using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

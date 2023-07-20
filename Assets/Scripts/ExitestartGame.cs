using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitRestartGame : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitGame()
    {
        Debug.Log("The end");
        Application.Quit();
    }
}

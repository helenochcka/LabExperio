using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] string SceneName;

    public void Transition()
    {
        SceneManager.LoadScene(SceneName);
    }
}

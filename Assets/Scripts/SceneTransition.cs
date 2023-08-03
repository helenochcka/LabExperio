using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
   public int sceneNumber;
   public void Transition()
    {
        SceneManager.LoadScene(sceneNumber);
    }
  
}

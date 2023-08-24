using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ApplicationController : MonoBehaviour
{
    private Animator animator;
    private string _sceneName;
    public void SetSceneName(string sceneName)
    {
        _sceneName = sceneName;
    }

    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    public void SceneTransition(string animatorStateName)
    {
        animator.Play(animatorStateName);
        IEnumerator coroutine = SceneTransitionCoroutine(_sceneName, animator.GetCurrentAnimatorStateInfo(0).length);
        StartCoroutine(coroutine);
    }

    private IEnumerator SceneTransitionCoroutine(string sceneName, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneName);
    }

    public void RestartActiveScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }
}

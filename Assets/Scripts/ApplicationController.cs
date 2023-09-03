using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ApplicationController : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponentInParent<Animator>();
    }

    public void SceneTransition(string sceneName)
    {
        AnimatorControllerParameter parameter = _animator.GetParameter(0);
        _animator.SetTrigger(parameter.name);
        IEnumerator coroutine = YieldSceneTransitionCoroutine(sceneName, _animator.GetCurrentAnimatorStateInfo(0).length);
        StartCoroutine(coroutine);
    }

    private IEnumerator YieldSceneTransitionCoroutine(string sceneName, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadActiveScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }
}

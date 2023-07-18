using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public void PlayGame()
    {
        _animator.enabled = true;
      
    }


    public void ExitGame()
    {
        Debug.Log("The end");
        Application.Quit();
    }
}
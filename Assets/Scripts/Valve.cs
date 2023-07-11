using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Valve : MonoBehaviour
{
    public Button startButton;
    public bool playersReady;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playersReady == true && startButton.interactable == false)
        {
            //allows the start button to be used
            startButton.interactable = true;
        }
    }
}

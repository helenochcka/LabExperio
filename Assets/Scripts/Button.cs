using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour
{
    public GameObject ValveButton;
    public bool ValveIsOpen;
    public Sprite OpenValve;
    public Sprite CloseValve;

    public void Start()
    {
        ValveIsOpen = false;
    }

    public void Update()
    {
        if (ValveIsOpen)
        {
            ValveButton.GetComponent<Image>().sprite = OpenValve;
        }
        else
        {
            ValveButton.GetComponent<Image>().sprite = CloseValve;
        }
    }

    public void onClick()
    {
        ValveIsOpen = !ValveIsOpen;
        Debug.Log(ValveIsOpen);
    }
}

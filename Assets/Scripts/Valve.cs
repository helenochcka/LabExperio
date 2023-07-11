using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour
{
    [SerializeField] private GameObject ValveButton;
    [SerializeField] private Sprite OpenValveSprite;
    [SerializeField] private Sprite CloseValveSprite;

    private bool ValveIsOpen;

    public void Start()
    {
        ValveIsOpen = false;
    }

    public void Update()
    {
        if (ValveIsOpen)
        {
            ValveButton.GetComponent<Image>().sprite = OpenValveSprite;
        }
        else
        {
            ValveButton.GetComponent<Image>().sprite = CloseValveSprite;
        }
    }

    public void OnClick()
    {
        ValveIsOpen = !ValveIsOpen;
        if (ValveIsOpen)
        {
            Debug.Log("Valve open");
        }
        else
        {
            Debug.Log("Valve closed");
        }
    }
}

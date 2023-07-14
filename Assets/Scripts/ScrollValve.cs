using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollValve : MonoBehaviour
{
    [SerializeField] Sprite OpenValveSprite;
    [SerializeField] Sprite CloseValveSprite;

    private decimal ValveOpeningDegree;
    private decimal WheelSpeed = 0.05m;

    public void Start()
    {
        ValveOpeningDegree = 0.0m;
    }

    public void Update()
    {
        if (ValveOpeningDegree <= 1.0m & ValveOpeningDegree >= 0.5m)
        {
            this.GetComponent<Image>().sprite = OpenValveSprite;
        }
        else
        {
            this.GetComponent<Image>().sprite = CloseValveSprite;
        }
    }
    void OnMouseEnter()
    {
        Debug.Log("Mouse Enter");
    }

    void OnMouseOver()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll < 0.0f)
        {
            if (ValveOpeningDegree <= 1.0m & ValveOpeningDegree > 0.0m)
            {
                ValveOpeningDegree -= WheelSpeed;
            }
        }
        else if (scroll > 0.0f)
        {
            if (ValveOpeningDegree < 1.0m & ValveOpeningDegree >= 0.0m)
            {
                ValveOpeningDegree += WheelSpeed;
            }
        }
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse Exit");
        Debug.Log(ValveOpeningDegree);
    }
}

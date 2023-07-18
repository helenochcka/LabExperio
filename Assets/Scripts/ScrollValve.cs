using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScrollValve : MonoBehaviour
{
    [SerializeField] Sprite OpenValveSprite;
    [SerializeField] Sprite CloseValveSprite;

    public decimal ValveOpeningDegree;
    private readonly decimal _wheelSpeed = 0.05m;

    public void Start()
    {
        ValveOpeningDegree = 0.0m;
    }

    public void Update()
    {
        if (ValveOpeningDegree % 0.02m == 0)
        {
            this.GetComponent<UnityEngine.UI.Image>().sprite = OpenValveSprite;
        }
        else
        {
            this.GetComponent<UnityEngine.UI.Image>().sprite = CloseValveSprite;
        }
    }

    void OnMouseOver()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll < 0.0f)
        {
            if (ValveOpeningDegree <= 1.0m & ValveOpeningDegree > 0.0m)
            {
                ValveOpeningDegree -= _wheelSpeed;
            }
        }
        else if (scroll > 0.0f)
        {
            if (ValveOpeningDegree < 1.0m & ValveOpeningDegree >= 0.0m)
            {
                ValveOpeningDegree += _wheelSpeed;
            }
        }

    }

    void OnMouseExit()
    {
        Debug.Log(ValveOpeningDegree);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class ScrollValve : MonoBehaviour
{
    //[SerializeField] Sprite OpenValveSprite;
    //[SerializeField] Sprite CloseValveSprite;

    public decimal ValveOpeningDegree;
    private readonly decimal _wheelSpeed = 0.05m;

    public void Start()
    {
        ValveOpeningDegree = 0.0m;
    }

    /*public void Update()
    {
        if (ValveOpeningDegree <= 1.0m & ValveOpeningDegree >= 0.3m)
        {
            this.GetComponent<Image>().sprite = OpenValveSprite;
        }
        else
        {
            this.GetComponent<Image>().sprite = CloseValveSprite;
        }
    }*/

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

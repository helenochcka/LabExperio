using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGlass : MonoBehaviour
{
    private decimal GlassPosition;
    private decimal WheelSpeed = 0.02m;
    private float OffsetValue = 0.02f;

    public void Start()
    {
        GlassPosition = 0.0m;
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
            if (GlassPosition <= 1.0m & GlassPosition > 0.0m)
            {
                GlassPosition -= WheelSpeed;
                this.transform.Translate(0, -OffsetValue, 0, Space.Self);
            }
        }
        else if (scroll > 0.0f)
        {
            if (GlassPosition < 1.0m & GlassPosition >= 0.0m)
            {
                GlassPosition += WheelSpeed;
                this.transform.Translate(0, OffsetValue, 0, Space.Self);
            }
        }
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse Exit");
        Debug.Log(GlassPosition);
    }
}

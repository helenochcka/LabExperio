using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGlass : MonoBehaviour
{
    private int GlassPosition;
    private bool UpButtonClicked;
    private bool DownButtonClicked;
    private float S = 0.5f;

    public void Start()
    {
        GlassPosition = 0;
    }

    public void OnClickUpButton()
    {
        if (GlassPosition == 0 || GlassPosition == 1)
        {
            UpButtonClicked = true;
            GlassPosition++;
        }
    }

    public void OnClickDownButton()
    {
        if (GlassPosition == 2 || GlassPosition == 1)
        {
            DownButtonClicked = true;
            GlassPosition--;
        }
    }

    public void Update()
    {
        if (UpButtonClicked)
        {
            this.transform.Translate(0, S, 0, Space.Self);
            UpButtonClicked = false;
        }
        if (DownButtonClicked)
        {
            this.transform.Translate(0, -S, 0, Space.Self);
            DownButtonClicked = false;
        }
    }
}

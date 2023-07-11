using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownMenu : MonoBehaviour
{
    public Text menu;

    public void InputMenu(int value)
    {  

        if(value == 0)
        {
        menu.text = "-";
        
        }

        if (value == 1)
        {
            menu.text = "0,1";
        
        }
        if (value == 2)
        {
            menu.text = "0,2";
        
        }
        if (value == 3)
        {
            menu.text = "0,3";
        
        }
    }
}

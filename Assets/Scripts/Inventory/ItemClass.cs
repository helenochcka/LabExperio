using System.Collections;
using UnityEngine;

public abstract class ItemClass : ScriptableObject

{
    [Header("Item")]
    public string itemName;
    public Sprite itemIcon;

    public abstract ItemClass GetItem();
    public abstract ToolClass GetTool();
}

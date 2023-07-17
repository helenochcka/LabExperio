using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName ="new Tool Class", menuName = "Item/Tool")]
public class ToolClass : ItemClass
{
    [Header("Tool")]
    public ToolType toolType;
    public enum ToolType
    {
        flask_0,
        flask_01,
        flask_02,
        flask_04,
        flask_08,
        flask_16,
        flask_32

    }
    public override ItemClass GetItem() { return this; }
    public override ToolClass GetTool() { return this; }

}

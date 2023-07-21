using UnityEngine;

public enum ItemType
    {
        flask_0,
        flask_01,
        flask_02,
        flask_04,
        flask_08,
        flask_16,
        flask_32
    }

[CreateAssetMenu(fileName = "new Item Class", menuName = "Item/Tool")]
public class Item : ScriptableObject
{
    [Header("Item")]
    public float itemValue;
    public Sprite itemIcon;
    public ItemType itemType;
}

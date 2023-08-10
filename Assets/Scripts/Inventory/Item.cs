using UnityEngine;

[CreateAssetMenu(fileName = "new Item Class", menuName = "Item/Tool")]
public class Item : ScriptableObject
{
    [Header("Item")]
    public float itemValue;
    public Sprite itemIcon;
}

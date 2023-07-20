using System.Collections;
using UnityEngine;

[System.Serializable]
public class SlotClass
{
    [SerializeField] private ItemClass item;

    public SlotClass()
    {
        item = null;
    }

    public SlotClass (ItemClass _item) 
    {
        item = _item;
    }

    public SlotClass(SlotClass slot)
    {
        this.item = slot.GetItem();
    }

    public void Clear()
    {
        this.item = null;
    }

    public ItemClass GetItem() { return item; }
   public void AddItem(ItemClass item)  
    {
        this.item = item;
    }
}

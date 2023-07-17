using System.Collections;
using UnityEngine;

[System.Serializable]
public class SlotClass
{
    [SerializeField] private ItemClass item;
    [SerializeField] private int quantity;

    public SlotClass()
    {
        item = null;
        quantity = 0;
    }

    public SlotClass (ItemClass _item, int _quantity)
    {
        item = _item;
        quantity = _quantity;
    }

    public SlotClass(SlotClass slot)
    {
        this.item = slot.GetItem();
        this.quantity = slot.GetQuantity();
    }

    public void Clear()
    {
        this.item = null;
        this.quantity = 0;
    }

    public ItemClass GetItem() { return item; }
    public int GetQuantity() { return quantity; }
    public void AddQuantity(int _quantity) { quantity += _quantity;  }
    public void SubQuantity(int _quantity) { quantity -= _quantity; }
    public void AddItem(ItemClass item, int quantity) 
    {
        this.item = item;
        this.quantity = quantity;
    }
}

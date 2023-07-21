using UnityEngine;

[System.Serializable]
public class Slot
{
    [SerializeField] private Item item;

    public Slot()
    {
        item = null;
    }

    public Slot(Item item) 
    {
        this.item = item;
    }

    public Slot(Slot slot)
    {
        this.item = slot.GetItem();
    }

    public void Clear()
    {
        this.item = null;
    }

    public Item GetItem() { return item; }
    public void AddItem(Item item)  
    {
        this.item = item;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject itemCursor;
    [SerializeField] private GameObject slotHolder;


    [SerializeField] private SlotClass[] startingItems;

    public SlotClass[] items; //make public

    private GameObject[] slots;

    private SlotClass movingSlot;
    private SlotClass tempSlot;
    private SlotClass originalSlot;
    bool isMovingItem;

    private void Start()
    {
        slots = new GameObject[slotHolder.transform.childCount];
        items = new SlotClass[slots.Length];

        for (int i = 0; i < items.Length; i++)
        {
            items[i] = new SlotClass();
        }

        for (int i = 0; i < startingItems.Length; i++)
        {
            items[i] = startingItems[i];
        }


        for (int i = 0; i < slotHolder.transform.childCount; i++)
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
       
        RefreshUI();

    }

    private void Update()
    {
        itemCursor.SetActive(isMovingItem);
        itemCursor.transform.position = Input.mousePosition;
        if (isMovingItem)
            itemCursor.GetComponent<Image>().sprite = movingSlot.GetItem().itemIcon;
        if (Input.GetMouseButtonDown(0))
        { 
            if(isMovingItem)
            {
                EndItemMove();
            }
            else 
                BeginItemMove();
        }
    }

    #region Inventory Utils
    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].GetItem().itemIcon;
            }
            catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
            }
        }
    }

    public bool Add(ItemClass item )

    {
        SlotClass slot = Contains(item);

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].GetItem() == null)
                {
                   items[i].AddItem(item);
         
                    RefreshUI();
                    return true;
                }

        }

        return false;
    }

    public SlotClass Contains(ItemClass item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].GetItem() == item)
                return items[i];
        }
        return null;

    }

    #endregion Inventory Utils

    #region Moving Stuff

    private bool BeginItemMove()
    {
        originalSlot = GetClosesSlot();
        if (originalSlot == null || originalSlot.GetItem() == null)
            return false;

        movingSlot = new SlotClass(originalSlot);
        originalSlot.Clear();
        isMovingItem = true;
        RefreshUI();
        return true;
    }

    private bool EndItemMove()
    {
        originalSlot = GetClosesSlot();

        if (originalSlot == null)
        { 
            Add(movingSlot.GetItem());
            movingSlot.Clear();
        }
        else
        {  
        if (originalSlot.GetItem() != null)
        {
            if (originalSlot.GetItem() == movingSlot.GetItem())
            {
                if (originalSlot.GetItem())
                {
                    movingSlot.Clear();
                }
                else
                    return false;
            }
            else
            {
                tempSlot = new SlotClass(originalSlot);
                originalSlot.AddItem(movingSlot.GetItem());
                    movingSlot.AddItem(tempSlot.GetItem());
                    RefreshUI();
                return true;
            }
        }
        else
        {
            originalSlot.AddItem(movingSlot.GetItem());
                movingSlot.Clear();
        }
        }
        isMovingItem = false;
        RefreshUI();
        return true;
    }
    private SlotClass GetClosesSlot()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (Vector2.Distance(slots[i].transform.position, Input.mousePosition) <= 32)
                return items[i];
        }
        return null;
    }
    #endregion Moving Stuff
}

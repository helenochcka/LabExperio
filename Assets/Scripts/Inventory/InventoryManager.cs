using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject Cursor;
    [SerializeField] GameObject Glass;
    [SerializeField] GameObject SlotHolder;
    
    public Slot[] Items;

    private GameObject[] _slots;
    private MoveGlass _moveGlass;
    private Slot _movingSlot;
    private Slot _tempSlot;
    private Slot _originalSlot;
    private bool _isMovingItem;

    private void Start()
    {
        _slots = new GameObject[SlotHolder.transform.childCount];
        _moveGlass = Glass.GetComponent<MoveGlass>();

        for (int i = 0; i < SlotHolder.transform.childCount; i++)
            _slots[i] = SlotHolder.transform.GetChild(i).gameObject;
       
        RefreshUI();
    }

    private void Update()
    {
        Cursor.SetActive(_isMovingItem);
        Cursor.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        if (_isMovingItem)
            Cursor.GetComponent<SpriteRenderer>().sprite = _movingSlot.GetItem().itemIcon;
        if (Input.GetMouseButtonDown(0))
        { 
            if(_isMovingItem)
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
        for (int i = 0; i < _slots.Length; i++)
        {
            try
            {
                _slots[i].transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                _slots[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Items[i].GetItem().itemIcon;
            }
            catch
            {
                _slots[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
                _slots[i].transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    public bool Add(Item item )
    {
        Slot slot = Contains(item);
        for (int i = 0; i < Items.Length; i++)
        {
            if (Items[i].GetItem() == null)
            {
                Items[i].AddItem(item);
                RefreshUI();
                return true;
            }
        }
        return false;
    }

    public Slot Contains(Item item)
    {
        for (int i = 0; i < Items.Length; i++)
        {
            if (Items[i].GetItem() == item)
                return Items[i];
        }
        return null;
    }

    #endregion Inventory Utils

    #region Moving Stuff

    private bool BeginItemMove()
    {
        _originalSlot = GetClosesSlot();
        if (_originalSlot == Items[0])
        {
            if (_moveGlass.GetGlassPosition() < 0.0m || _moveGlass.GetGlassPosition() > 0.46m)
            {
                return false;
            }
        }
        if (_originalSlot == null || _originalSlot.GetItem() == null)
            return false;

        _movingSlot = new Slot(_originalSlot);
        _originalSlot.Clear();
        _isMovingItem = true;
        RefreshUI();
        return true;
    }

    private bool EndItemMove()
    {
        _originalSlot = GetClosesSlot();

        if (_originalSlot == null)
        {
            Add(_movingSlot.GetItem());
            _movingSlot.Clear();
        }
        else
        {  
            if (_originalSlot.GetItem() != null)
            {
                if (_originalSlot.GetItem() == _movingSlot.GetItem())
                {
                    if (_originalSlot.GetItem())
                    {
                        _movingSlot.Clear();
                    }
                    else
                        return false;
                }
                else if (_originalSlot == Items[0])
                {
                    if (_moveGlass.GetGlassPosition() < 0.0m || _moveGlass.GetGlassPosition() > 0.46m)
                    {
                        return false;
                    }
                }
                else
                {
                    _tempSlot = new Slot(_originalSlot);
                    _originalSlot.AddItem(_movingSlot.GetItem());
                    _movingSlot.AddItem(_tempSlot.GetItem());
                    RefreshUI();
                    return true;
                }
            }
            else
            {
                _originalSlot.AddItem(_movingSlot.GetItem());
                    _movingSlot.Clear();
            }
        }
        _isMovingItem = false;
        RefreshUI();
        return true;
    }

    private Slot GetClosesSlot()
    {
        for(int i = 0; i < _slots.Length; i++)
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouseWorldPosition2D = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPosition2D, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == _slots[i])
            {
                return Items[i];
            }
        }
        return null;
    }
    #endregion Moving Stuff
}
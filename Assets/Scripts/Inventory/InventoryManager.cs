using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject Cursor;
    [SerializeField] GameObject MainGlass;
    [SerializeField] GameObject SlotHolder;
    [SerializeField] Slot[] Slots;

    private Slot _mainSlot;
    private GameObject[] _slots;
    private MainGlass _mainGlass;
    private Slot _movingSlot;
    private Slot _tempSlot;
    private Slot _currentSlot;
    private bool _isGlassMoving;

    void Start()
    {
        _mainSlot = Slots[0];
        _slots = new GameObject[SlotHolder.transform.childCount];
        _mainGlass = MainGlass.GetComponent<MainGlass>();

        for (int i = 0; i < SlotHolder.transform.childCount; i++)
            _slots[i] = SlotHolder.transform.GetChild(i).gameObject;
       
        RefreshInventory();
    }

    void Update()
    {
        Cursor.SetActive(_isGlassMoving);
        Cursor.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

        if (_isGlassMoving)
            Cursor.GetComponent<SpriteRenderer>().sprite = _movingSlot.GetGlass().Icon;
        if (Input.GetMouseButtonDown(0))
        { 
            if(_isGlassMoving)
            {
                EndItemMove();
            }
            else 
                BeginIGlassMove();
        }
    }

    public Slot GetMainSlot()
    {
        return _mainSlot;
    }

    public void RefreshInventory()
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            try
            {
                _slots[i].transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                _slots[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Slots[i].GetGlass().Icon;
            }
            catch
            {
                _slots[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
                _slots[i].transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    public void ReturnGlass()
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            if (Slots[i].GetGlass() == null)
            {
                Slots[i].SetGlass(_movingSlot.GetGlass());
                _movingSlot.CLear();
                _isGlassMoving = false;
                RefreshInventory();
            }
        }
    }

    private void BeginIGlassMove()
    {
        _currentSlot = GetClosestSlot();
        if (_currentSlot == _mainSlot && _mainGlass.PositionCategory != PositionCategory.TooLow)
            return;
        if (_currentSlot == null || _currentSlot.GetGlass() == null)
            return;

        _movingSlot = new Slot();
        _movingSlot.SetGlass(_currentSlot.GetGlass());
        _currentSlot.CLear();
        _isGlassMoving = true;
        RefreshInventory();
    }

    private void EndItemMove()
    {
        _currentSlot = GetClosestSlot();

        if (_currentSlot == null || _currentSlot.GetGlass() == null)
        {
            ReturnGlass();
            return;
        }
        if (_currentSlot == _mainSlot && _mainGlass.PositionCategory != PositionCategory.TooLow)
            return;
        _tempSlot = new Slot();
        _tempSlot.SetGlass(_currentSlot.GetGlass());
        _currentSlot.SetGlass(_movingSlot.GetGlass());
        _movingSlot.SetGlass(_tempSlot.GetGlass());
        RefreshInventory();
    }

    private Slot GetClosestSlot()
    {
        for(int i = 0; i < _slots.Length; i++)
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouseWorldPosition2D = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPosition2D, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == _slots[i])
            {
                return Slots[i];
            }
        }
        return null;
    }
}
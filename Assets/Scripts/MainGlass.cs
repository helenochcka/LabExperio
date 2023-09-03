using UnityEngine;

public class MainGlass : MonoBehaviour
{
    [SerializeField] GameObject Solution;
    private const decimal MouseWheelStep = 0.02m;
    private const decimal UpperBoundGlassPosition = 0.56m;
    private const decimal LowerBoundGlassPosition = 0.48m;

    private decimal _position;
    private PositionCategory _positionCategory;
    private float _solutionConcentration;
    private InventoryManager _inventoryManager;
    private Glass _glass;

    public float SolutionConcentration => _solutionConcentration;
    public PositionCategory PositionCategory => _positionCategory;

    void Start()
    {
        _inventoryManager = Solution.GetComponent<InventoryManager>();
        _position = 0.0m;
    }

    void Update()
    {
        _glass = _inventoryManager.GetMainSlot().GetGlass();
        if (_glass != null)
            _solutionConcentration = _glass.Concentration;
    }

    void OnMouseOver()
    {
        float scrollAxisValue = Input.GetAxis("Mouse ScrollWheel");
        if (scrollAxisValue < 0.0f && (_position > 0.0m && _position <= 1.0m))
        {
                _position -= MouseWheelStep;
                this.transform.Translate(0, (float)-MouseWheelStep, 0);
        }
        else if (scrollAxisValue > 0.0f && (_position < 1.0m && _position >= 0.0m))
        {
                _position += MouseWheelStep;
                this.transform.Translate(0, (float)MouseWheelStep, 0);
        }
        _positionCategory = DeterminePositionCategory(_position);
    }

    private PositionCategory DeterminePositionCategory(decimal position)
    {
        PositionCategory positionCategory;

        if (position > UpperBoundGlassPosition)
            positionCategory = PositionCategory.TooHigh;
        else if (position < LowerBoundGlassPosition)
            positionCategory = PositionCategory.TooLow;
        else
            positionCategory = PositionCategory.Correct;

        return positionCategory;
    }
}

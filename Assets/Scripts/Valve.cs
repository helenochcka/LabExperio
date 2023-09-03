using UnityEngine;

public class Valve : MonoBehaviour
{
    private const decimal LowerBoundOfCorrectOpeningDegree = 0.25m;
    private const decimal UpperBoundOfCorrectOpeningDegree = 0.35m;
    private const float RotationFactor = 120f;
    private const decimal MouseWheelStep = 0.05m;

    [SerializeField] GameObject Flask;
    [SerializeField] GameObject Warning;

    private SystemAnimationController _systemAnimationController;
    private Flask _flask;
    private decimal _openingDegree;
    private DrippingState _drippingState;

    public DrippingState DrippingState => _drippingState;

    void Start()
    {
        _flask = Flask.GetComponent<Flask>();
        _systemAnimationController = GetComponentInParent<SystemAnimationController>();
        _openingDegree = 0.0m;
        _drippingState = DrippingState.NotDripping;
    }

    void Update()
    {
        if (_flask.IsFull) 
        {
            _openingDegree = 0.0m;
            Warning.SetActive(true);
        }
        DetermineDrippingState();
        _systemAnimationController.PlayDrippingAnimation(_drippingState);
    }

    void OnMouseOver()
    {
        if (!_flask.IsFull)
        {
            float scrollAxisValue = Input.GetAxis("Mouse ScrollWheel");
            if (scrollAxisValue < 0.0f && (_openingDegree <= 1.0m && _openingDegree > 0.0m))
            {
                _openingDegree -= MouseWheelStep;
                this.transform.Rotate(0, 0, (float)MouseWheelStep * RotationFactor);
            }
            else if (scrollAxisValue > 0.0f && (_openingDegree < 1.0m && _openingDegree >= 0.0m))
            {
                _openingDegree += MouseWheelStep;
                this.transform.Rotate(0, 0, (float)-MouseWheelStep * RotationFactor);
            }
        }
    }

    private void DetermineDrippingState()
    {
        if ((_openingDegree >= 0) && (_openingDegree <= LowerBoundOfCorrectOpeningDegree))
            _drippingState = DrippingState.NotDripping;
        else if ((_openingDegree > UpperBoundOfCorrectOpeningDegree) && (_openingDegree <= 1))
            _drippingState = DrippingState.DrippingFast;
        else
            _drippingState = DrippingState.DrippingSlow;
    }
}

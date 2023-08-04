using UnityEngine;

public class Valve : MonoBehaviour
{
    private const decimal LowerBoundOfCorrectOpeningDegree = 0.25m;
    private const decimal UpperBoundOfCorrectOpeningDegree = 0.35m;
    private const float RotationFactor = 120f;
    private const decimal MouseWheelStep = 0.05m;

    [SerializeField] GameObject Drops;
    [SerializeField] GameObject Flask;
    [SerializeField] GameObject Warning;

    private Animator _animator;
    private Flask _flask;
    private decimal _openingDegree;
    private DrippingState _drippingState;
    public DrippingState DrippingState => _drippingState;

    void Start()
    {
        _flask = Flask.GetComponent<Flask>();
        _animator = Drops.GetComponent<Animator>();
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
        _drippingState = DetermineDrippingState(_openingDegree);
        PlayDrippingAnimation(_drippingState);
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

    private DrippingState DetermineDrippingState(decimal openingDegree)
    {
        DrippingState drippingState;

        if ((openingDegree >= 0) && (openingDegree <= LowerBoundOfCorrectOpeningDegree))
            drippingState = DrippingState.NotDripping;
        else if ((openingDegree > UpperBoundOfCorrectOpeningDegree) && (openingDegree <= 1))
            drippingState = DrippingState.DrippingFast;
        else
            drippingState = DrippingState.DrippingSlow;

        return drippingState;
    }

    private void PlayDrippingAnimation(DrippingState drippingState)
    {
        AnimatorControllerParameter parameter = _animator.GetParameter((int)drippingState);
        _animator.SetTrigger(parameter.name);
    }
}

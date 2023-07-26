using UnityEngine;

public class Bottle : MonoBehaviour
{
    [SerializeField] GameObject Valve;
    [SerializeField] GameObject Drops;

    private Animator _animator;
    private Valve _valve;
    private DrippingState _drippingState;
    public DrippingState DrippingState => _drippingState;

    void Start()
    {
        _drippingState = DrippingState.NotDripping;
        _valve = Valve.GetComponent<Valve>();
        _animator = Drops.GetComponent<Animator>();
    }

    void Update()
    {
        _drippingState = DetermineDrippingState(_valve.OpeningDegree);
    }

    private DrippingState DetermineDrippingState(decimal valveOpeningDegree)
    {
        DrippingState drippingState;
        if (valveOpeningDegree <= 0.35m & valveOpeningDegree >= 0.25m)
        {
            drippingState = DrippingState.DrippingSlow;
            AnimatorControllerParameter parameter = _animator.GetParameter((int)drippingState);
            _animator.SetTrigger(parameter.name);
        }
        else if (valveOpeningDegree <= 1 & valveOpeningDegree > 0.35m)
        {
            drippingState = DrippingState.DrippingFast;
            AnimatorControllerParameter parameter = _animator.GetParameter((int)drippingState);
            _animator.SetTrigger(parameter.name);
        }
        else
        {
            drippingState = DrippingState.NotDripping;
            AnimatorControllerParameter parameter = _animator.GetParameter((int)drippingState);
            _animator.SetTrigger(parameter.name);
        }
        return drippingState;
    }
}

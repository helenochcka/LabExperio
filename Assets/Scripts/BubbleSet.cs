using UnityEngine;

public class BubbleSet : MonoBehaviour
{
    [SerializeField] GameObject Glass;
    [SerializeField] GameObject Bubbles;
    [SerializeField] GameObject Bottle;
    
    private Animator _animator;
    private Glass _glass;
    private Bottle _bottle;
    private string _establishingProcess;

    public string EstablishingProcess => _establishingProcess;

    void Start()
    {
        _establishingProcess = "";
        _glass = Glass.GetComponent<Glass>();
        _bottle = Bottle.GetComponent<Bottle>();
        _animator = Bubbles.GetComponent<Animator>();
    }

    void Update()
    {
        _establishingProcess = BlowingBubbles(_bottle.DrippingState, _glass.Position);
    }

    private string BlowingBubbles(DrippingState drippingState, decimal glassPosition)
    {
        string establishingProcess;
        if (drippingState == DrippingState.NotDripping)
        {
            establishingProcess = "Inactive";
            AnimatorControllerParameter parameter = _animator.GetParameter(0);
            _animator.SetTrigger(parameter.name);
        }
        else if (drippingState == DrippingState.DrippingSlow)
        {
            if (glassPosition >= 0.48m & glassPosition <= 0.56m)
            {
                establishingProcess = "SlowActive";
                AnimatorControllerParameter parameter = _animator.GetParameter(1);
                _animator.SetTrigger(parameter.name);
            }
            else if (glassPosition < 0.48m)
            {
                establishingProcess = "Inactive";
                AnimatorControllerParameter parameter = _animator.GetParameter(0);
                _animator.SetTrigger(parameter.name);
            }
            else
            {
                establishingProcess = "FastActive";
                AnimatorControllerParameter parameter = _animator.GetParameter(0);
                _animator.SetTrigger(parameter.name);
            }
        }
        else if (drippingState == DrippingState.DrippingFast)
        {
            if (glassPosition >= 0.48m & glassPosition <= 0.56m)
            {
                establishingProcess = "SlowActive";
                AnimatorControllerParameter parameter = _animator.GetParameter(2);
                _animator.SetTrigger(parameter.name);
            }
            else if (glassPosition < 0.48m)
            {
                establishingProcess = "Inactive";
                AnimatorControllerParameter parameter = _animator.GetParameter(0);
                _animator.SetTrigger(parameter.name);
            }
            else
            {
                establishingProcess = "FastActive";
                AnimatorControllerParameter parameter = _animator.GetParameter(0);
                _animator.SetTrigger(parameter.name);
            }
        }
        else
        {
            establishingProcess = "Inactive";
            AnimatorControllerParameter parameter = _animator.GetParameter(0);
            _animator.SetTrigger(parameter.name);
        }
        return establishingProcess;
    }
}

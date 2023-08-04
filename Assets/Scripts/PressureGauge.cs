using UnityEngine;

public class PressureGauge : MonoBehaviour
{
    [SerializeField] GameObject LeftState;
    [SerializeField] GameObject RightState;
    [SerializeField] GameObject Glass;
    [SerializeField] GameObject Bubbles;
    [SerializeField] GameObject Valve;

    private Animator _animator;
    private Glass _glass;
    private Valve _valve;
    private string _establishingProcess;

    private Vector3 _startScaleLeftState;
    private Vector3 _startScaleRightState;

    void Start()
    {
        _establishingProcess = "";
        _glass = Glass.GetComponent<Glass>();
        _valve = Valve.GetComponent<Valve>();
        _animator = Bubbles.GetComponent<Animator>();

        _startScaleLeftState = LeftState.transform.localScale;
        _startScaleRightState = RightState.transform.localScale;
    }

    void Update()
    {
        PlayBlowBubblesAnimation(_valve.DrippingState, _glass.PositionCategory);
        _establishingProcess = BlowingBubbles(_valve.DrippingState, _glass.PositionCategory);
        EstablishValueStates(_establishingProcess, CheckSolution(_glass.SolutionConcentration));
    }
        

    private float CheckSolution(float concentration)
    {
        float pressureGaugePosition;
        switch (concentration)
        {
            case 0.0f:
                pressureGaugePosition = 1.5f;
                break;
            case 0.1f:
                pressureGaugePosition = 1.18f;
                break;
            case 0.2f:
                pressureGaugePosition = 1.1f;
                break;
            case 0.4f:
                pressureGaugePosition = 1.09f;
                break;
            case 0.8f:
                pressureGaugePosition = 1.08f;
                break;
            case 1.6f:
                pressureGaugePosition = 1.07f;
                break;
            case 3.2f:
                pressureGaugePosition = 1.06f;
                break;
            default:
                pressureGaugePosition = 0.0f;
                break;
        }
        return pressureGaugePosition;
    }

    private void EstablishValueStates(string establishingProcess, float pressureGaugePosition)
    {
        if (establishingProcess.Equals("Inactive"))
        {
            LeftState.transform.localScale = _startScaleLeftState;
            RightState.transform.localScale = _startScaleRightState;
        }
        else if (establishingProcess.Equals("SlowActive"))
        {
            LeftState.transform.localScale = new Vector3(_startScaleLeftState.x, _startScaleLeftState.y / pressureGaugePosition, _startScaleLeftState.z);
            RightState.transform.localScale = new Vector3(_startScaleRightState.x, _startScaleRightState.y * pressureGaugePosition, _startScaleRightState.z);
        }
        else if (establishingProcess.Equals("FastActive"))
        {
            LeftState.transform.localScale = new Vector3(_startScaleLeftState.x, _startScaleLeftState.y / (pressureGaugePosition + 0.2f), _startScaleLeftState.z);
            RightState.transform.localScale = new Vector3(_startScaleRightState.x, _startScaleRightState.y * (pressureGaugePosition + 0.2f), _startScaleRightState.z);
        }
    }

    private string BlowingBubbles(DrippingState drippingState, PositionCategory positionCategory)
    {
        string establishingProcess;
        if (drippingState == DrippingState.NotDripping)
        {
            establishingProcess = "Inactive";
        }
        else if (drippingState == DrippingState.DrippingSlow)
        {
            if (positionCategory == PositionCategory.Correct)
            {
                establishingProcess = "SlowActive";
            }
            else if (positionCategory == PositionCategory.TooLow)
            {
                establishingProcess = "Inactive";
            }
            else
            {
                establishingProcess = "FastActive";
            }
        }
        else if (drippingState == DrippingState.DrippingFast)
        {
            if (positionCategory == PositionCategory.Correct)
            {
                establishingProcess = "SlowActive";
            }
            else if (positionCategory == PositionCategory.TooLow)
            {
                establishingProcess = "Inactive";
            }
            else
            {
                establishingProcess = "FastActive";
            }
        }
        else
        {
            establishingProcess = "Inactive";
        }
        return establishingProcess;
    }

    private void PlayBlowBubblesAnimation(DrippingState drippingState, PositionCategory positionCategory)
    {
        AnimatorControllerParameter parameter;
        if (positionCategory == PositionCategory.Correct)
        {
            if (drippingState == DrippingState.DrippingSlow)
            {
                parameter = _animator.GetParameter(1);
            }
            else if (drippingState == DrippingState.DrippingFast)
            {
                parameter = _animator.GetParameter(2);
            }
            else
            {
                parameter = _animator.GetParameter(0);
            }
        }
        else
        {
            parameter = _animator.GetParameter(0);
        }
        _animator.SetTrigger(parameter.name);
    }
}

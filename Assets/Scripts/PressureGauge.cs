using UnityEngine;

public class PressureGauge : MonoBehaviour
{
    [SerializeField] GameObject LeftState;
    [SerializeField] GameObject RightState;
    [SerializeField] GameObject MainGlass;
    [SerializeField] GameObject Valve;

    private SystemAnimationController _systemAnimationController;
    private MainGlass _mainGlass;
    private Valve _valve;
    private string _establishingProcess;
    private Vector3 _startScaleLeftState;
    private Vector3 _startScaleRightState;

    void Start()
    {
        _systemAnimationController = GetComponentInParent<SystemAnimationController>();
        _establishingProcess = "";
        _mainGlass = MainGlass.GetComponent<MainGlass>();
        _valve = Valve.GetComponent<Valve>();
        _startScaleLeftState = LeftState.transform.localScale;
        _startScaleRightState = RightState.transform.localScale;
    }

    void Update()
    {
        _systemAnimationController.PlayBlowBubblesAnimation(_valve.DrippingState, _mainGlass.PositionCategory);
        _establishingProcess = BlowingBubbles(_valve.DrippingState, _mainGlass.PositionCategory);
        EstablishValueStates(_establishingProcess, CheckSolution(_mainGlass.SolutionConcentration));
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
}

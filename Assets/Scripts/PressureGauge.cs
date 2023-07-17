using UnityEngine;

public class PressureGauge : MonoBehaviour
{
    [SerializeField] GameObject Flask;
    //[SerializeField] GameObject Solution;
    [SerializeField] GameObject LeftState;
    [SerializeField] GameObject RightState;

    private BlowBubbles _blowBubbles;
    private FillFlask _fillFlask;
    //private NameClass _nameClass;
    private Vector3 _startScaleLeftState;
    private Vector3 _startScaleRightState;

    void Start()
    {
        _fillFlask = Flask.GetComponent<FillFlask>();
        _blowBubbles = this.GetComponent<BlowBubbles>();
        //_nameClass = Solution.GetComponent<NameClass>();
        _startScaleLeftState = LeftState.transform.localScale;
        _startScaleRightState = RightState.transform.localScale;
    }

    void Update()
    {
        if (_fillFlask.FlaskIsFullness == false)
        {
            EstablishValueStates(_blowBubbles.EstablishingProcess, CheckSolution("0")); //_nameClass.Concentration
        }
        else
        {
            //???
        }
    }

    private float CheckSolution(string concentration) //add real value
    {
    float pressureGaugePosition;
        switch (concentration)
        {
            case "0":
                pressureGaugePosition = 1.2f;
                break;
            case "0.1":
                pressureGaugePosition = 1f;
                break;
            case "0.2":
                pressureGaugePosition = 1f;
                break;
            case "0.4":
                pressureGaugePosition = 1f;
                break;
            case "0.8":
                pressureGaugePosition = 1f;
                break;
            case "1.6":
                pressureGaugePosition = 1f;
                break;
            case "3.2":
                pressureGaugePosition = 1f;
                break;
            default:
                pressureGaugePosition = 1f;
                break;
        }
        return pressureGaugePosition;
    }

    private void EstablishValueStates(string establishingProcess, float pressureGaugePosition) //add smoothly transform
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
            LeftState.transform.localScale = new Vector3(_startScaleLeftState.x, _startScaleLeftState.y * pressureGaugePosition, _startScaleLeftState.z);
            RightState.transform.localScale = new Vector3(_startScaleRightState.x, _startScaleRightState.y / pressureGaugePosition, _startScaleRightState.z);
        }
        else
        {
            LeftState.transform.localScale = _startScaleLeftState;
            RightState.transform.localScale = _startScaleRightState;
        }
    }
}

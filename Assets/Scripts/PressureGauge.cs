using UnityEngine;

public class PressureGauge : MonoBehaviour
{
    [SerializeField] GameObject Glass;
    [SerializeField] GameObject Valve;
    //[SerializeField] GameObject Solution;
    [SerializeField] GameObject LeftState;
    [SerializeField] GameObject RightState;

    private MoveGlass _moveGlass;
    private ScrollValve _scrollValve;

    private float _pressureGaugePosition;
    private Vector3 _startLeftStateVector3;
    private Vector3 _startRightStateVector3;

    void Start()
    {
        _moveGlass = Glass.GetComponent<MoveGlass>();
        _scrollValve = Valve.GetComponent<ScrollValve>();
        //Solution.GetComponent<>();
        _startLeftStateVector3 = LeftState.transform.position;
        _startRightStateVector3 = RightState.transform.position;
    }

    void Update()
    {
        LeftState.transform.position = new Vector3(_startLeftStateVector3.x, _startLeftStateVector3.y - MovePressure(_moveGlass.GlassPosition, _scrollValve.ValveOpeningDegree), _startLeftStateVector3.z);
        RightState.transform.position = new Vector3(_startRightStateVector3.x, _startRightStateVector3.y + MovePressure(_moveGlass.GlassPosition, _scrollValve.ValveOpeningDegree), _startRightStateVector3.z);
    }

    private float MovePressure(decimal _glassPosition, decimal _valveOpeningDegree) //add a concentration parameter
    {
        if (_valveOpeningDegree >= 0.25m & _valveOpeningDegree <= 0.35m) //the valve is in the correct position
        {
            if (_glassPosition >= 0.44m & _glassPosition <= 0.54m) //the dropper is in the correct position
            {
                _pressureGaugePosition = 0.5f; //at different concentration values
            }
            else if (_glassPosition < 0.44m)    //the dropper doesn't touch with liquid
            {
                _pressureGaugePosition = 0f;
            }
            else                                //the dropper is immersed too deeply
            {
                _pressureGaugePosition = 0f;
            }
        }
        else if (_valveOpeningDegree < 0.25m)   //the valve is closed
        {
            _pressureGaugePosition = 0f;
        }
        else                                  //the valve is too open
        {
            _pressureGaugePosition = 0f;
        }
        return _pressureGaugePosition;
    }
}

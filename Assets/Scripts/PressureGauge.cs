using UnityEngine;

public class PressureGauge : MonoBehaviour
{
    private const float RangeOscillationPercentage = 0.15f;
    [SerializeField] GameObject LeftLevel;
    [SerializeField] GameObject RightLevel;
    [SerializeField] GameObject MainGlass;
    [SerializeField] GameObject Valve;

    private SystemAnimationController _systemAnimationController;
    private MainGlass _mainGlass;
    private Valve _valve;
    private float _value;
    private Vector3 _startScaleLeftLevel;
    private Vector3 _startScaleRightLevel;
    private float _timeFromLastLevelUpdate = 0.0f;

    void Start()
    {
        _systemAnimationController = GetComponentInParent<SystemAnimationController>();
        _mainGlass = MainGlass.GetComponent<MainGlass>();
        _valve = Valve.GetComponent<Valve>();
        _value = Glass.ConcentrationToHightMapping[_mainGlass.SolutionConcentration];
        _startScaleLeftLevel = LeftLevel.transform.localScale;
        _startScaleRightLevel = RightLevel.transform.localScale;
    }

    void Update()
    {
        _timeFromLastLevelUpdate += Time.deltaTime;
        _systemAnimationController.PlayBlowBubblesAnimation(_valve.DrippingState, _mainGlass.PositionCategory);
        OscillateValue();
        EstablishLevels(_valve.DrippingState, _mainGlass.PositionCategory);
    }

    private void EstablishLevels(DrippingState valveDrippingState, PositionCategory glassPositionCategory)
    {
        if (valveDrippingState == DrippingState.NotDripping || glassPositionCategory == PositionCategory.TooLow)
        {
            SetValue(1.0f);
        }
        else if (glassPositionCategory == PositionCategory.Correct)
        {
            SetValue(_value);
        }
        else if (glassPositionCategory == PositionCategory.TooHigh)
        {
            SetValue(_value + 0.2f);
        }
    }

    private void OscillateValue()
    {
        if (_timeFromLastLevelUpdate >= 0.2f)
        {
            _value = Glass.ConcentrationToHightMapping[_mainGlass.SolutionConcentration];
            if (_valve.DrippingState == DrippingState.DrippingFast)
            {
                _timeFromLastLevelUpdate = 0.0f;
                _value += Random.Range(-RangeOscillationPercentage, RangeOscillationPercentage);
            }
        }
    }

    private void SetValue(float value)
    {
        LeftLevel.transform.localScale = new Vector3(_startScaleLeftLevel.x, _startScaleLeftLevel.y / value, _startScaleLeftLevel.z);
        RightLevel.transform.localScale = new Vector3(_startScaleRightLevel.x, _startScaleRightLevel.y * value, _startScaleRightLevel.z);
    }
}

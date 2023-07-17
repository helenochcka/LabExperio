using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditorInternal.VersionControl.ListControl;

public class FillFlask : MonoBehaviour
{
    [SerializeField] GameObject Liquid;
    [SerializeField] GameObject ElbowTube;
    [SerializeField] GameObject Warning;
    public bool FlaskIsFullness;

    private DripWater _dripWater;
    private float UpdateDelta;
    private float _flaskFullnessValue;
    private Vector3 _startScaleLiquid;

    void Start()
    {
        _startScaleLiquid = Liquid.transform.localScale;
        _dripWater = ElbowTube.GetComponent<DripWater>();
        _flaskFullnessValue = 0f;
    }

    void Update()
    {
        if (_dripWater.DrippingProcess.Equals("Inactive"))
        {
            //???
        }
        else if (_dripWater.DrippingProcess.Equals("SlowDrip"))
        {
            SlowFillingFlask();
        }
        else if (_dripWater.DrippingProcess.Equals("FastDrip"))
        {
            FastFillingFlask();
        }
        ChangeScaleLiquid();
        FlaskIsFullness = CheckFillFlask(_flaskFullnessValue);
    }

    private bool CheckFillFlask(float flaskFullnessValue)
    {
        bool FlaskIsFullness;
        if (flaskFullnessValue < 100)
        {
            FlaskIsFullness = false;
        }
        else
        {
            FlaskIsFullness = true;
            Warning.SetActive(true);
        }
        return FlaskIsFullness;
    }

    private void SlowFillingFlask()
    {
        UpdateDelta += Time.deltaTime;
        if (UpdateDelta >= 2f)
        {
            UpdateDelta = 0f;
            _flaskFullnessValue++;
        }
    }

    private void FastFillingFlask()
    {
        UpdateDelta += Time.deltaTime;
        if (UpdateDelta >= 0.2f)
        {
            UpdateDelta = 0f;
            _flaskFullnessValue++;
        }
    }

    private void ChangeScaleLiquid()
    {
        Liquid.transform.localScale = new Vector3(_startScaleLiquid.x, _startScaleLiquid.y * _flaskFullnessValue, _startScaleLiquid.z);
    }
}

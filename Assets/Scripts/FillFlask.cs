using UnityEngine;

public class FillFlask : MonoBehaviour
{
    [SerializeField] GameObject ElbowTube;
    [SerializeField] GameObject Warning;
    public bool FlaskIsFull;
    public float _flaskFullnessValue;

    private DripWater _dripWater;
    private float UpdateDelta;

    void Start()
    {
        _dripWater = ElbowTube.GetComponent<DripWater>();
        _flaskFullnessValue = 0f;
    }

    void Update()
    {
        if (_dripWater.DrippingProcess.Equals("SlowDrip"))
        {
            SlowFillingFlask();
        }
        else if (_dripWater.DrippingProcess.Equals("FastDrip"))
        {
            FastFillingFlask();
        }
        FlaskIsFull = IsFlaskFull(_flaskFullnessValue);
    }

    private bool IsFlaskFull(float flaskFullnessValue)
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
}

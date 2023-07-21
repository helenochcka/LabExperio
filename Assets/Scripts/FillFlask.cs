using UnityEngine;

public class FillFlask : MonoBehaviour
{
    [SerializeField] GameObject ElbowTube;
        
    private float _flaskFullnessValue;
    private DripWater _dripWater;
    private float _updateDelta;

    void Start()
    {
        _dripWater = ElbowTube.GetComponent<DripWater>();
        _flaskFullnessValue = 0f;
    }

    void Update()
    {
        if (_dripWater.GetDrippingProcess().Equals("SlowDrip"))
        {
            SlowFillingFlask();
        }
        else if (_dripWater.GetDrippingProcess().Equals("FastDrip"))
        {
            FastFillingFlask();
        }
    }

    private void SlowFillingFlask()
    {
        _updateDelta += Time.deltaTime;
        if (_updateDelta >= 2f)
        {
            _updateDelta = 0f;
            _flaskFullnessValue++;
        }
    }

    private void FastFillingFlask()
    {
        _updateDelta += Time.deltaTime;
        if (_updateDelta >= 0.2f)
        {
            _updateDelta = 0f;
            _flaskFullnessValue++;
        }
    }

    public float GetFlaskFullnessValue() { return _flaskFullnessValue; }
}

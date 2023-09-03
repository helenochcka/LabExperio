using UnityEngine;

public class Flask: MonoBehaviour
{
    private const float LongLevelUpdateTime = 2f;
    private const float ShortLevelUpdateTime = 0.2f;
    [SerializeField] GameObject Valve;
    [SerializeField] GameObject Liquid;

    private float _fullnessPercentage;
    private Valve _valve;
    private GameObject[] _visualLiquidLevels;
    private float _timeFromLastLevelUpdate = 0.0f;
    private float _intervalBetweenLevels;
    public bool IsFull => _fullnessPercentage == 100;

    void Start()
    {
        _valve = Valve.GetComponent<Valve>();
        _fullnessPercentage = 0f;
        InitializeVisualLiquidLevels();
        _intervalBetweenLevels = 100 / _visualLiquidLevels.Length;
    }

    private void InitializeVisualLiquidLevels()
    {
        _visualLiquidLevels = new GameObject[Liquid.transform.childCount];
        for (int i = 0; i < _visualLiquidLevels.Length; i++)
        {
            _visualLiquidLevels[i] = Liquid.transform.GetChild(i).gameObject;
        }
    }

    void Update()
    {
        if (_valve.DrippingState == DrippingState.DrippingSlow)
        {
            Fill(LongLevelUpdateTime);
        }
        else if (_valve.DrippingState == DrippingState.DrippingFast)
        {
            Fill(ShortLevelUpdateTime);
        }
    }

    private void Fill(float currentLevelUpdateTime)
    {
        _timeFromLastLevelUpdate += Time.deltaTime;
        if (_timeFromLastLevelUpdate >= currentLevelUpdateTime)
        {
            _timeFromLastLevelUpdate = 0f;
            _fullnessPercentage++;
        }
        if ((_fullnessPercentage != 0) && (_fullnessPercentage % _intervalBetweenLevels == 0))
            _visualLiquidLevels[(int)(_fullnessPercentage / _intervalBetweenLevels) - 1].SetActive(true);
    }
}

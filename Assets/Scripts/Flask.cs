using UnityEngine;

public class Flask: MonoBehaviour
{
    private const float LongLevelUpdateTime = 2f;
    private const float ShortLevelUpdateTime = 0.2f;
    [SerializeField] GameObject Valve;
        
    private float _occupancyLevel;
    private Valve _valve;
    private float _timeFromLastLevelUpdate;
    
    public float OccurancyLevel => _occupancyLevel;
    public bool IsFull => _occupancyLevel == 100;

    void Start()
    {
        _valve = Valve.GetComponent<Valve>();
        _occupancyLevel = 0f;
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
            _occupancyLevel++;
        }
    }
}

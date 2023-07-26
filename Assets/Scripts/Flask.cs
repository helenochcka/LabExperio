using UnityEngine;

public class Flask: MonoBehaviour
{
    private const float LongLevelUpdateTime = 2f;
    private const float ShortLevelUpdateTime = 0.2f;
    [SerializeField] GameObject Bottle;
        
    private float _occupancyLevel;
    private Bottle _bottle;
    private float _timeFromLastLevelUpdate;
    
    public float OccurancyLevel => _occupancyLevel;
    public bool IsFull => _occupancyLevel == 100 ? true : false;

    void Start()
    {
        _bottle = Bottle.GetComponent<Bottle>();
        _occupancyLevel = 0f;
    }

    void Update()
    {
        if (_bottle.DrippingState == DrippingState.DrippingSlow)
        {
            Fill(LongLevelUpdateTime);
        }
        else if (_bottle.DrippingState == DrippingState.DrippingFast)
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

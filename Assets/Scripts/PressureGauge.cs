using UnityEngine;

public class PressureGauge : MonoBehaviour
{
    [SerializeField] GameObject Solution;
    [SerializeField] GameObject LeftState;
    [SerializeField] GameObject RightState;

    private BlowBubbles _blowBubbles;
    private InventoryManager _inventoryManager;
    private ItemClass _itemClass;
    private Vector3 _startScaleLeftState;
    private Vector3 _startScaleRightState;

    void Start()
    {
        _blowBubbles = this.GetComponent<BlowBubbles>();
        _inventoryManager = Solution.GetComponent<InventoryManager>();
        _startScaleLeftState = LeftState.transform.localScale;
        _startScaleRightState = RightState.transform.localScale;
    }

    void Update()
    {
        _itemClass = _inventoryManager.items[6].GetItem();
        EstablishValueStates(_blowBubbles.EstablishingProcess, CheckSolution(_itemClass.itemName));
    }

    private float CheckSolution(string concentration) //add real value
    {
        float pressureGaugePosition;
        switch (concentration)
        {
            case "0":
                pressureGaugePosition = 1.03f;
                break;
            case "0.1":
                pressureGaugePosition = 1.06f;
                break;
            case "0.2":
                pressureGaugePosition = 1.09f;
                break;
            case "0.4":
                pressureGaugePosition = 1.12f;
                break;
            case "0.8":
                pressureGaugePosition = 1.15f;
                break;
            case "1.6":
                pressureGaugePosition = 1.18f;
                break;
            case "3.2":
                pressureGaugePosition = 1.21f;
                break;
            default:
                pressureGaugePosition = 1.24f;
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
    }
}

﻿using UnityEngine;

public class PressureGauge : MonoBehaviour
{
    [SerializeField] GameObject Solution;
    [SerializeField] GameObject LeftState;
    [SerializeField] GameObject RightState;

    private BlowBubbles _blowBubbles;
    private InventoryManager _inventoryManager;
    private Item _item;
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
        _item = _inventoryManager.Items[0].GetItem();
        if (_item != null )
        {
            EstablishValueStates(_blowBubbles.GetEstablishingProcess(), CheckSolution(_item.itemValue));
        }
    }

    private float CheckSolution(float concentration)
    {
        float pressureGaugePosition;
        switch (concentration)
        {
            case 0.0f:
                pressureGaugePosition = 1.03f;
                break;
            case 0.1f:
                pressureGaugePosition = 1.06f;
                break;
            case 0.2f:
                pressureGaugePosition = 1.09f;
                break;
            case 0.4f:
                pressureGaugePosition = 1.12f;
                break;
            case 0.8f:
                pressureGaugePosition = 1.15f;
                break;
            case 1.6f:
                pressureGaugePosition = 1.18f;
                break;
            case 3.2f:
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

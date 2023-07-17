using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DripWater : MonoBehaviour
{
    [SerializeField] GameObject Valve;
    public string DrippingProcess;

    private ScrollValve _scrollValve;

    void Start()
    {
        _scrollValve = Valve.GetComponent<ScrollValve>();
    }

    void Update()
    {
        DrippingProcess = DrippingWater(_scrollValve.ValveOpeningDegree);
    }

    public string DrippingWater(decimal valveOpeningDegree)
    {
        string drippingProcess;
        if (valveOpeningDegree >= 0.25m & valveOpeningDegree <= 0.35m)
        {
            drippingProcess = "SlowDrip";
            //add animation slow drip water (1 time per 2 sec)
        }
        else if (valveOpeningDegree < 0.25m)
        {
            drippingProcess = "Inactive";
        }
        else
        {
            drippingProcess = "FastDrip";
            //add animation fast drip water (1 time per 0.2 sec)
        }

        return drippingProcess;
    }
}

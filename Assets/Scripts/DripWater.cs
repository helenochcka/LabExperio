using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DripWater : MonoBehaviour
{
    [SerializeField] GameObject Valve;
    [SerializeField] GameObject Drops;
    public string DrippingProcess;
    
    public Animator _anim;

    private ScrollValve _scrollValve;

    void Start()
    {
        _scrollValve = Valve.GetComponent<ScrollValve>();
        _anim = Drops.GetComponent<Animator>();
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
            _anim.SetTrigger("PlaySlowDripWater");
        }
        else if (valveOpeningDegree < 0.25m)
        {
            drippingProcess = "Inactive";
            _anim.SetTrigger("Stop");
        }
        else
        {
            drippingProcess = "FastDrip";
            _anim.SetTrigger("PlayFastDripWater");
        }

        return drippingProcess;
    }
}

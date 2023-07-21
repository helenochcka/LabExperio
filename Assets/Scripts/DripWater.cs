using UnityEngine;

public class DripWater : MonoBehaviour
{
    [SerializeField] GameObject Valve;
    [SerializeField] GameObject Drops;
    [SerializeField] Animator Anim;

    private string _drippingProcess;
    private ScrollValve _scrollValve;

    void Start()
    {
        _drippingProcess = "";
        _scrollValve = Valve.GetComponent<ScrollValve>();
        Anim = Drops.GetComponent<Animator>();
    }

    void Update()
    {
        _drippingProcess = DrippingWater(_scrollValve.GetValveOpeningDegree());
    }

    private string DrippingWater(decimal valveOpeningDegree)
    {
        string drippingProcess;
        if (valveOpeningDegree >= 0.25m & valveOpeningDegree <= 0.35m)
        {
            drippingProcess = "SlowDrip";
            Anim.SetTrigger("PlaySlowDripWater");
        }
        else if (valveOpeningDegree >= 0 & valveOpeningDegree < 0.25m)
        {
            drippingProcess = "Inactive";
            Anim.SetTrigger("Stop");
        }
        else if (valveOpeningDegree <= 1 & valveOpeningDegree > 0.35m)
        {
            drippingProcess = "FastDrip";
            Anim.SetTrigger("PlayFastDripWater");
        }
        else
        {
            drippingProcess = "Inactive";
            Anim.SetTrigger("StopAll");
        }
        return drippingProcess;
    }

    public string GetDrippingProcess() { return _drippingProcess; }
}

using UnityEngine;

public class BlowBubbles : MonoBehaviour
{
    [SerializeField] GameObject Glass;
    [SerializeField] GameObject ElbowTube;
    public string EstablishingProcess;

    private MoveGlass _moveGlass;
    private DripWater _dripWater;
    
    void Start()
    {
        _moveGlass = Glass.GetComponent<MoveGlass>();
        _dripWater = ElbowTube.GetComponent<DripWater>();
    }

    void Update()
    {
        EstablishingProcess = BlowingBubbles(_dripWater.DrippingProcess, _moveGlass.GlassPosition);
    }

    private string BlowingBubbles(string drippingProcess, decimal glassPosition)
    {
        string establishingProcess;
        if (drippingProcess.Equals("Inactive"))
        {
            establishingProcess = "Inactive";
        }
        else if (drippingProcess.Equals("SlowDrip"))
        {
            if (glassPosition >= 0.44m & glassPosition <= 0.54m)
            {
                establishingProcess = "SlowActive";
                //add animation slow blow bubble (1 time per 4 sec)
            }
            else if (glassPosition < 0.44m)
            {
                establishingProcess = "Inactive";
                //
            }
            else
            {
                establishingProcess = "FastActive";
                //add animation fast blow bubble (1 time per 0.4 sec)
            }
        }
        else if (drippingProcess.Equals("FastDrip"))
        {
            if (glassPosition >= 0.44m & glassPosition <= 0.54m)
            {
                establishingProcess = "FastActive";
                //add animation fast blow bubble (1 time per 0.4 sec)
            }
            else if (glassPosition < 0.44m)
            {
                establishingProcess = "Inactive";
                //
            }
            else
            {
                establishingProcess = "SlowActive";
                //add animation slow blow bubble (1 time per 4 sec)
            }
        }
        else
        {
            establishingProcess = "Inactive";
        }

        return establishingProcess;
    }
}

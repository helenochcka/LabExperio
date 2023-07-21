using UnityEngine;

public class BlowBubbles : MonoBehaviour
{
    [SerializeField] GameObject Glass;
    [SerializeField] GameObject Bubbles;
    [SerializeField] GameObject ElbowTube;
    [SerializeField] Animator Anim;

    private string _establishingProcess;
    private MoveGlass _moveGlass;
    private DripWater _dripWater;
    
    void Start()
    {
        _establishingProcess = "";
        _moveGlass = Glass.GetComponent<MoveGlass>();
        _dripWater = ElbowTube.GetComponent<DripWater>();
        Anim = Bubbles.GetComponent<Animator>();
    }

    void Update()
    {
        _establishingProcess = BlowingBubbles(_dripWater.GetDrippingProcess(), _moveGlass.GetGlassPosition());
    }

    private string BlowingBubbles(string drippingProcess, decimal glassPosition)
    {
        string establishingProcess;
        if (drippingProcess.Equals("Inactive"))
        {
            establishingProcess = "Inactive";
            Anim.SetTrigger("Stop");
        }
        else if (drippingProcess.Equals("SlowDrip"))
        {
            if (glassPosition >= 0.48m & glassPosition <= 0.56m)
            {
                establishingProcess = "SlowActive";
                Anim.SetTrigger("PlayBlowOneBubble");
            }
            else if (glassPosition < 0.48m)
            {
                establishingProcess = "Inactive";
                Anim.SetTrigger("Stop");
            }
            else
            {
                establishingProcess = "FastActive";
                Anim.SetTrigger("Stop");
            }
        }
        else if (drippingProcess.Equals("FastDrip"))
        {
            if (glassPosition >= 0.48m & glassPosition <= 0.56m)
            {
                establishingProcess = "SlowActive";
                Anim.SetTrigger("PlayBlowManyBubble");
            }
            else if (glassPosition < 0.48m)
            {
                establishingProcess = "Inactive";
                Anim.SetTrigger("Stop");
            }
            else
            {
                establishingProcess = "FastActive";
                Anim.SetTrigger("Stop");
            }
        }
        else
        {
            establishingProcess = "Inactive";
            Anim.SetTrigger("Stop");
        }
        return establishingProcess;
    }

    public string GetEstablishingProcess() { return _establishingProcess; }
}

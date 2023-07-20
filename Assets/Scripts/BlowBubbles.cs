using UnityEngine;

public class BlowBubbles : MonoBehaviour
{
    [SerializeField] GameObject Glass;
    [SerializeField] GameObject Bubbles;
    [SerializeField] GameObject ElbowTube;
    public string EstablishingProcess;

    public Animator _anim;

    private MoveGlass _moveGlass;
    private DripWater _dripWater;
    
    void Start()
    {
        _moveGlass = Glass.GetComponent<MoveGlass>();
        _dripWater = ElbowTube.GetComponent<DripWater>();
        _anim = Bubbles.GetComponent<Animator>();
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
            _anim.SetTrigger("Stop");
        }
        else if (drippingProcess.Equals("SlowDrip"))
        {
            if (glassPosition >= 0.44m & glassPosition <= 0.54m)
            {
                establishingProcess = "SlowActive";
                _anim.SetTrigger("PlayBlowOneBubble");
            }
            else if (glassPosition < 0.44m)
            {
                establishingProcess = "Inactive";
                _anim.SetTrigger("Stop");
            }
            else
            {
                establishingProcess = "FastActive";
                _anim.SetTrigger("PlayBlowManyBubble");
            }
        }
        else if (drippingProcess.Equals("FastDrip"))
        {
            if (glassPosition >= 0.44m & glassPosition <= 0.54m)
            {
                establishingProcess = "FastActive";
                _anim.SetTrigger("PlayBlowManyBubble");
            }
            else if (glassPosition < 0.44m)
            {
                establishingProcess = "Inactive";
                _anim.SetTrigger("Stop");
            }
            else
            {
                establishingProcess = "SlowActive";
                _anim.SetTrigger("PlayBlowOneBubble");
            }
        }
        else
        {
            establishingProcess = "Inactive";
            _anim.SetTrigger("Stop");
        }

        return establishingProcess;
    }
}

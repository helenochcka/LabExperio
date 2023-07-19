using UnityEngine;

public class ScrollValve : MonoBehaviour
{
    [SerializeField] GameObject Flask;
    public decimal ValveOpeningDegree;

    private readonly decimal _wheelSpeed = 0.05m;
    private FillFlask _fillFlask;

    public void Start()
    {
        _fillFlask = Flask.GetComponent<FillFlask>();
        ValveOpeningDegree = 0.0m;
    }

    public void Update()
    {
        if (_fillFlask.FlaskIsFull == true) 
        {
            ValveOpeningDegree = -1.0m;
        }
    }

    void OnMouseOver()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll < 0.0f)
        {
            if (ValveOpeningDegree <= 1.0m & ValveOpeningDegree > 0.0m)
            {
                ValveOpeningDegree -= _wheelSpeed;
                this.transform.Rotate(0,0, (float)_wheelSpeed*120);
            }
        }
        else if (scroll > 0.0f)
        {
            if (ValveOpeningDegree < 1.0m & ValveOpeningDegree >= 0.0m)
            {
                ValveOpeningDegree += _wheelSpeed;
                this.transform.Rotate(0, 0, (float)-_wheelSpeed*120);
            }
        }

    }

    void OnMouseExit()
    {
        Debug.Log(ValveOpeningDegree);
    }
}

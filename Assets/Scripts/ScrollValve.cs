using Unity.VisualScripting;
using UnityEngine;

public class ScrollValve : MonoBehaviour
{
    [SerializeField] GameObject Flask;
    [SerializeField] GameObject Warning;

    private decimal _valveOpeningDegree;
    private readonly decimal _wheelSpeed = 0.05m;
    private FillFlask _fillFlask;

    public void Start()
    {
        _fillFlask = Flask.GetComponent<FillFlask>();
        _valveOpeningDegree = 0.0m;
    }

    public void Update()
    {
        if (_fillFlask.GetFlaskFullnessValue() == 100) 
        {
            _valveOpeningDegree = -1.0m;
            Warning.SetActive(true);
        }
    }

    void OnMouseOver()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll < 0.0f)
        {
            if (_valveOpeningDegree <= 1.0m & _valveOpeningDegree > 0.0m)
            {
                _valveOpeningDegree -= _wheelSpeed;
                this.transform.Rotate(0,0, (float)_wheelSpeed*120);
            }
        }
        else if (scroll > 0.0f)
        {
            if (_valveOpeningDegree < 1.0m & _valveOpeningDegree >= 0.0m)
            {
                _valveOpeningDegree += _wheelSpeed;
                this.transform.Rotate(0, 0, (float)-_wheelSpeed*120);
            }
        }

    }

    public decimal GetValveOpeningDegree() { return _valveOpeningDegree; }
}

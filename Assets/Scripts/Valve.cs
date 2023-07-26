using UnityEngine;

public class Valve : MonoBehaviour
{
    private const float RotationFactor = 120f;
    private const decimal MouseWheelStep = 0.05m;

    [SerializeField] GameObject Flask;
    [SerializeField] GameObject Warning;

    private Flask _flask;
    private decimal _openingDegree;
    public decimal OpeningDegree => _openingDegree;

    void Start()
    {
        _flask = Flask.GetComponent<Flask>();
        _openingDegree = 0.0m;
    }

    void Update()
    {
        if (_flask.IsFull) 
        {
            _openingDegree = 0.0m;
            Warning.SetActive(true);
        }
    }

    void OnMouseOver()
    {
        if (!_flask.IsFull)
        {
            float scrollAxisValue = Input.GetAxis("Mouse ScrollWheel");
            if (scrollAxisValue < 0.0f & (_openingDegree <= 1.0m & _openingDegree > 0.0m))
            {
                _openingDegree -= MouseWheelStep;
                this.transform.Rotate(0, 0, (float)MouseWheelStep * RotationFactor);
            }
            else if (scrollAxisValue > 0.0f & (_openingDegree < 1.0m & _openingDegree >= 0.0m))
            {
                _openingDegree += MouseWheelStep;
                this.transform.Rotate(0, 0, (float)-MouseWheelStep * RotationFactor);
            }
        }
    }
}

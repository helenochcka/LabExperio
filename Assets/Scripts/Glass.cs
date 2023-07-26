using UnityEngine;

public class Glass : MonoBehaviour
{
    private const decimal MouseWheelStep = 0.02m;

    private decimal _position;
    public decimal Position => _position;

    void Start()
    {
        _position = 0.0m;
    }

    void OnMouseOver()
    {
        float scrollAxisValue = Input.GetAxis("Mouse ScrollWheel");
        if (scrollAxisValue < 0.0f & (_position > 0.0m & _position <= 1.0m))
        {
                _position -= MouseWheelStep;
                this.transform.Translate(0, (float)-MouseWheelStep, 0);
        }
        else if (scrollAxisValue > 0.0f & (_position < 1.0m & _position >= 0.0m))
        {
                _position += MouseWheelStep;
                this.transform.Translate(0, (float)MouseWheelStep, 0);
        }
    }
}

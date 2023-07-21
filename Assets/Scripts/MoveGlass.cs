using UnityEngine;

public class MoveGlass : MonoBehaviour
{
    private decimal _glassPosition;
    private readonly decimal _wheelSpeed = 0.02m;

    public void Start()
    {
        _glassPosition = 0.0m;
    }

    void OnMouseOver()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll < 0.0f)
        {
            if (_glassPosition <= 1.0m & _glassPosition > 0.0m)
            {
                _glassPosition -= _wheelSpeed;
                this.transform.Translate(0, (float)-_wheelSpeed / 2, 0);
                this.transform.Translate(0, (float)-_wheelSpeed / 2, 0);
            }
        }
        else if (scroll > 0.0f)
        {
            if (_glassPosition < 1.0m & _glassPosition >= 0.0m)
            {
                _glassPosition += _wheelSpeed;
                this.transform.Translate(0, (float)_wheelSpeed / 2, 0);
                this.transform.Translate(0, (float)_wheelSpeed / 2, 0);
            }
        }
    }

    public decimal GetGlassPosition() { return _glassPosition; }
}

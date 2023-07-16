using UnityEngine;

public class MoveGlass : MonoBehaviour
{
    public decimal GlassPosition;
    private readonly decimal _wheelSpeed = 0.02m;

    public void Start()
    {
        GlassPosition = 0.0m;
    }

    void OnMouseOver()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll < 0.0f)
        {
            if (GlassPosition <= 1.0m & GlassPosition > 0.0m)
            {
                GlassPosition -= _wheelSpeed;
                this.transform.Translate(0, (float)-_wheelSpeed, 0, Space.Self);
            }
        }
        else if (scroll > 0.0f)
        {
            if (GlassPosition < 1.0m & GlassPosition >= 0.0m)
            {
                GlassPosition += _wheelSpeed;
                this.transform.Translate(0, (float)_wheelSpeed, 0, Space.Self);
            }
        }
    }

    void OnMouseExit()
    {
        Debug.Log(GlassPosition);
    }
}

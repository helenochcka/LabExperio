using UnityEngine;

public class MoveGlass : MonoBehaviour
{
    [SerializeField] GameObject Item;
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
                Item.transform.Translate(0, (float)-_wheelSpeed*100, 0);
            }
        }
        else if (scroll > 0.0f)
        {
            if (GlassPosition < 1.0m & GlassPosition >= 0.0m)
            {
                GlassPosition += _wheelSpeed;
                Item.transform.Translate(0, (float)_wheelSpeed*100, 0);
            }
        }
    }

    void OnMouseExit()
    {
        Debug.Log(GlassPosition);
    }
}

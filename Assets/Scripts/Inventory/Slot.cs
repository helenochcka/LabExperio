using UnityEngine;

[System.Serializable]
public class Slot
{
    [SerializeField] Glass Glass;

    public void SetGlass(Glass glass)
    {
        Glass = glass;
    }

    public void CLear()
    {
        Glass = null;
    }

    public Glass GetGlass() { return Glass; }
}

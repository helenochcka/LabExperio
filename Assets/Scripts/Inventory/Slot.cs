using UnityEngine;

[System.Serializable]
public class Slot
{
    [SerializeField] Glass Glass;

    public void SetGlass(Glass glass)
    {
        this.Glass = glass;
    }

    public void CLear()
    {
        this.Glass = null;
    }

    public Glass GetGlass() { return Glass; }
}

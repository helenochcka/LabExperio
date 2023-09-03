using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Glass", menuName = "Glass")]
public class Glass : ScriptableObject
{
    public float Concentration;
    public Sprite Icon;
    public static Dictionary<float, float> ConcentrationToHightMapping = new Dictionary<float, float>()
        {
            { 0.0f, 1.5f },
            { 0.1f, 1.18f },
            { 0.2f, 1.1f },
            { 0.4f, 1.09f },
            { 0.8f, 1.08f },
            { 1.6f, 1.07f },
            { 3.2f, 1.06f }
        };
}

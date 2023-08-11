using UnityEngine;

public class ChangeLiquid : MonoBehaviour
{
    [SerializeField] GameObject Flask;
    [SerializeField] Sprite u1;
    [SerializeField] Sprite u2;
    [SerializeField] Sprite u3;
    [SerializeField] Sprite u4;
    [SerializeField] Sprite u5;
    [SerializeField] Sprite u6;
    [SerializeField] Sprite u7;
    [SerializeField] Sprite u8;
    [SerializeField] Sprite u9;
    [SerializeField] Sprite u10;
    [SerializeField] Sprite u11;
    [SerializeField] Sprite u12;
    [SerializeField] Sprite u13;
    [SerializeField] Sprite u14;
    [SerializeField] Sprite u15;
    [SerializeField] Sprite u16;
    [SerializeField] Sprite u17;
    [SerializeField] Sprite u18;
    [SerializeField] Sprite u19;
    [SerializeField] Sprite u20;

    private Flask _flask;

    void Start()
    {
        _flask = Flask.GetComponent<Flask>();
    }

    void Update()
    {
        switch (_flask.OccurancyLevel) // U.. = (OccurancyLevel + 1 / 5)
        {
            case 4:
                this.GetComponent<SpriteRenderer>().sprite = u1;
                break;
            case 9:
                this.GetComponent<SpriteRenderer>().sprite = u2;
                break;
            case 14:
                this.GetComponent<SpriteRenderer>().sprite = u3;
                break;
            case 19:
                this.GetComponent<SpriteRenderer>().sprite = u4;
                break;
            case 24:
                this.GetComponent<SpriteRenderer>().sprite = u5;
                break;
            case 29:
                this.GetComponent<SpriteRenderer>().sprite = u6;
                break;
            case 34:
                this.GetComponent<SpriteRenderer>().sprite = u7;
                break;
            case 39:
                this.GetComponent<SpriteRenderer>().sprite = u8;
                break;
            case 44:
                this.GetComponent<SpriteRenderer>().sprite = u9;
                break;
            case 49:
                this.GetComponent<SpriteRenderer>().sprite = u10;
                break;
            case 54:
                this.GetComponent<SpriteRenderer>().sprite = u11;
                break;
            case 59:
                this.GetComponent<SpriteRenderer>().sprite = u12;
                break;
            case 64:
                this.GetComponent<SpriteRenderer>().sprite = u13;
                break;
            case 69:
                this.GetComponent<SpriteRenderer>().sprite = u14;
                break;
            case 74:
                this.GetComponent<SpriteRenderer>().sprite = u15;
                break;
            case 79:
                this.GetComponent<SpriteRenderer>().sprite = u16;
                break;
            case 84:
                this.GetComponent<SpriteRenderer>().sprite = u17;
                break;
            case 89:
                this.GetComponent<SpriteRenderer>().sprite = u18;
                break;
            case 94:
                this.GetComponent<SpriteRenderer>().sprite = u19;
                break;
            case 99:
                this.GetComponent<SpriteRenderer>().sprite = u20;
                break;
            default: break;
        }
    }
}

using UnityEngine;

public class SystemAnimationController : MonoBehaviour
{
    [SerializeField] GameObject Drops;
    [SerializeField] GameObject Bubbles;
    private Animator _dropsAnimator;
    private Animator _bubblesAnimator;

    void Start()
    {
        _dropsAnimator = Drops.GetComponent<Animator>();
        _bubblesAnimator = Bubbles.GetComponent<Animator>();
    }

    public void PlayDrippingAnimation(DrippingState drippingState)
    {
        AnimatorControllerParameter parameter = _dropsAnimator.GetParameter((int)drippingState);
        _dropsAnimator.SetTrigger(parameter.name);
    }

    public void PlayBlowBubblesAnimation(DrippingState drippingState, PositionCategory positionCategory)
    {
        AnimatorControllerParameter parameter;
        if (positionCategory == PositionCategory.Correct)
        {
            if (drippingState == DrippingState.DrippingSlow)
            {
                parameter = _bubblesAnimator.GetParameter(1);
            }
            else if (drippingState == DrippingState.DrippingFast)
            {
                parameter = _bubblesAnimator.GetParameter(2);
            }
            else
            {
                parameter = _bubblesAnimator.GetParameter(0);
            }
        }
        else
        {
            parameter = _bubblesAnimator.GetParameter(0);
        }
        _bubblesAnimator.SetTrigger(parameter.name);
    }
}

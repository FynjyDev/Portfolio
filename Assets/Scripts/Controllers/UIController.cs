using UnityEngine;

public class UIController : MonoBehaviour
{
    public Joystick joystick;


    public void UpdateResourceValue(ResourceInfo _resourceInfo)
    {
        _resourceInfo.resourcePanel.resourceCountText.text = _resourceInfo.resourceCount.ToString();
        _resourceInfo.resourcePanel.panelAnimator.SetTrigger("ValueChange");
    }
}

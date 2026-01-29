using UnityEngine;
using UnityEngine.EventSystems;

public class MobileControlButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] MobileControls mobileControls;
    [SerializeField] MovementKey movementKey;
    
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        mobileControls.OnMovementKeyDown(movementKey);
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        mobileControls.OnMovementKeyUp(movementKey);
    }
}

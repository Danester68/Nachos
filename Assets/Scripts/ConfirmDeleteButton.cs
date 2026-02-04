using UnityEngine;
using UnityEngine.EventSystems;

public class ConfirmDeleteButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] LoadLevelMenu loadLevelMenu;
    
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        loadLevelMenu.UpdateConfirmDeleteButtonState(true);
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        loadLevelMenu.UpdateConfirmDeleteButtonState(false);
    }
}

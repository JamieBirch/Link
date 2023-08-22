using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Word : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler
{
    public Image hoverBox;
    private bool dragging = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Debug.Log("OnMouseEnter");
        hoverBox.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Debug.Log("OnMouseExit");
        hoverBox.enabled = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //TODO
        Debug.Log("Dragging");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragPoint : MonoBehaviour, IPointerClickHandler, IPointerUpHandler, IPointerEnterHandler
{
    public DragGame parent;

    public void OnPointerClick(PointerEventData eventData)
    {
        parent.dragObject.gameObject.SetActive(true);
        parent.dragObject.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
        parent.dragObject.PickingPosition = Input.mousePosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }
}

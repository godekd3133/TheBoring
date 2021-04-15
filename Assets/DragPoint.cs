using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragPoint : MonoBehaviour, IPointerUpHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public DragGame parent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        parent.dragObject.gameObject.SetActive(true);
        parent.dragObject.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
        parent.dragObject.PickingPosition = Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragObject collect = Instantiate(parent.dragObject, parent.transform);
        collect.transform.position = parent.dragObject.transform.position;
        collect.transform.rotation = parent.dragObject.transform.rotation;
        collect.GetComponent<RectTransform>().sizeDelta = parent.dragObject.GetComponent<RectTransform>().sizeDelta;
        collect.enabled = false;

        parent.dragObject.gameObject.SetActive(false);
    }
    

    public void OnPointerUp(PointerEventData eventData)
    {
    }
}

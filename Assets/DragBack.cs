using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragBack : MonoBehaviour, IPointerUpHandler
{
    public DragObject dragObject = null;
    public void OnPointerUp(PointerEventData eventData)
    {
        dragObject.gameObject.SetActive(false);
    }
}

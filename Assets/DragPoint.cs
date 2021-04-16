using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragPoint : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public int index;
    public DragGame parent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        parent.dragObject.gameObject.SetActive(true);
        parent.dragObject.transform.position = this.transform.position;
        parent.dragObject.PickingPosition = this.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        parent.gr.Raycast(eventData, results);
        
        if(results.Count <= 0)
            parent.dragObject.gameObject.SetActive(false);
        DragPoint point;

        int findIndex = 0;
        for(int i = 0; i < results.Count; i++)
        {
            if (results[i].gameObject.GetComponent<DragPoint>())
                findIndex = i;
        }


        if (results[findIndex].gameObject.TryGetComponent<DragPoint>(out point))
        {
            bool isCollect = false;
            for(int i = 0; i < parent.collectStartIndex.Length; i++)
            {
                if (parent.collectStartIndex[i] == index)
                {
                    if (parent.collectEndIndex[i] == point.index)
                    {
                        parent.collectText[i].color = new Color(151f / 255f,
                            156f / 255f,
                            170f / 255f);

                        parent.collectStartIndex[i] = parent.collectEndIndex[i] = -1;
                        parent.collectIndex -= 1;
                        isCollect = true;
                        parent.resultPoint++;
                        parent.pointText.text = parent.resultPoint.ToString();

                        parent.CheckWin();
                        break;
                    }
                }

                if (parent.collectStartIndex[i] == point.index)
                {
                    if (parent.collectEndIndex[i] == index)
                    {
                        parent.collectText[i].color = new Color(151f / 255f,
                            156f / 255f,
                            170f / 255f);

                        parent.collectStartIndex[i] = parent.collectEndIndex[i] = -1;
                        parent.collectIndex -= 1;
                        isCollect = true;
                        parent.resultPoint++;
                        parent.pointText.text = parent.resultPoint.ToString();

                        parent.CheckWin();
                        break;
                    }
                }
            }
            if(isCollect)
            {
                DragObject collect = Instantiate(parent.dragObject, parent.DragObjectsParent.transform);
                collect.SetCell(point);

                collect.enabled = false;
            }

        }
        
        parent.dragObject.gameObject.SetActive(false);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragObject : MonoBehaviour
{
    public RectTransform tp = null;
    public Image image = null;

    public Vector2 PickingPosition = Vector2.zero;

    public RectTransform rectTp = null;

    private void Start()
    {
        rectTp = GameObject.Find("Canvas").GetComponent<RectTransform>();
    }

    public void ResetObj()
    {
        tp.sizeDelta = new Vector2(0, 30);
        tp.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void Update()
    {
        Vector2 direction = (Vector2)Input.mousePosition - PickingPosition;
        
        float z = Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x);
        
        tp.rotation = Quaternion.Euler(0, 0, z);

        tp.sizeDelta = new Vector2((Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2))) * 0.7f, 30);
    }

    public void SetCell(DragPoint point)
    {
        Vector2 direction = (Vector2)point.transform.position - PickingPosition;

        float z = Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x);

        tp.rotation = Quaternion.Euler(0, 0, z);

        tp.sizeDelta = new Vector2((Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2)) )* 0.7f, 30);
    }


}

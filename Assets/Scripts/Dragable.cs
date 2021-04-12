using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragable : MonoBehaviour
{
    public bool isOn = false;
    public EventTrigger trigger;
    RectTransform rectTransform;
    Vector2 position;
    public GameObject[] holds;
    public Holder holder;
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        trigger = gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener(data => OnDown(data));
        trigger.triggers.Add(entry);
        EventTrigger.Entry entryUp = new EventTrigger.Entry();
        entryUp.eventID = EventTriggerType.PointerUp;
        entryUp.callback.AddListener(data => OnUp(data));
        trigger.triggers.Add(entryUp);
        EventTrigger.Entry drag = new EventTrigger.Entry();
        drag.eventID = EventTriggerType.Drag;
        drag.callback.AddListener(data => OnDrag(data));
        trigger.triggers.Add(drag);

        rectTransform = GetComponent<RectTransform>();
        position = transform.position;
    }

    private void OnDrag(BaseEventData data)
    {
        PointerEventData point = (PointerEventData)data;
        transform.position = point.position;
    }

    private void OnUp(BaseEventData data)
    {
        isOn = false;
        var holded = false;
        foreach(var hold in holds)
        {
            if(Vector3.Distance(hold.transform.position, transform.position) < 30)
            {
                transform.position = hold.transform.position;
                holded = true;
                var holdSet = hold.GetComponent<Holder>();
                if(holdSet.dragable != null)
                {
                    holdSet.dragable.Reset();
                }
                holdSet.dragable = this;
                this.holder = holdSet;
            }
        }
        if (!holded)
        {
            if(holder != null)
            {
                holder.dragable = null;
            }
            Reset();
        }
    }

    private void OnDown(BaseEventData data)
    {
        isOn = true;
    }

    public void Reset()
    {
        if (position == null) return;
        transform.position = position;

    }


    // Update is called once per frame
    void Update()
    {
    }
}

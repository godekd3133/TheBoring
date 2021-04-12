using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public CardGame game;
    private EventTrigger trigger;
    public GameObject source;
    private Image image;
    bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        trigger = gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener(data => OnClick(data));
        trigger.triggers.Add(entry);
        image = GetComponent<Image>();
        source = transform.GetChild(0).gameObject;
        source.SetActive(false);
    }

    void OnClick(BaseEventData data)
    {
        if (isOpen) return;
        isOpen = true;
        source.SetActive(true);
        game.SetCard(transform.GetSiblingIndex()+1);
    }

    public void Reset()
    {
        Invoke("Clear", 1f)
;    }

    public void Clear()
    {
        isOpen = false;
        source.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

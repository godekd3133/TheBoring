using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour
{
    EventTrigger eventTrigger;
    Text text;
    Image image;

    private List<RectTransform> listText;
    int currentIndex = 0;

    public bool enableOnStart;
    public bool disableOnEnd;

    private void Awake()
    {
        eventTrigger = GetComponent<EventTrigger>();
        text = GetComponentInChildren<Text>();
        image = GetComponent<Image>();
        listText = GetComponentsInChildren<RectTransform>().ToList();
        listText.Remove(GetComponent<RectTransform>());
    }

    void Start()
    {
        if (enableOnStart)
            ResetSpeetch();
        else
            DisableSpeetch();


        EventTrigger.Entry entry_Click = new EventTrigger.Entry();
        entry_Click.eventID = EventTriggerType.PointerClick;
        entry_Click.callback.AddListener((data) => { OnClick((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_Click);

    }

    public void OnClick(PointerEventData eventData)
    {

        Next();

    }


    public void Next()
    {
        if (currentIndex >= listText.Count - 1 && !disableOnEnd)
            return;
        listText[currentIndex].gameObject.SetActive(false);
        currentIndex++;
        if (currentIndex == listText.Count)
        {
            if (disableOnEnd == true)
                DisableSpeetch();
        }
        else listText[currentIndex].gameObject.SetActive(true);

    }

    //말풍선 처음부터
    public void ResetSpeetch()
    {
        image.enabled = true;
        foreach (var each in listText)
        {
            each.gameObject.SetActive(false);
        }

        currentIndex = 0;
        listText[currentIndex].gameObject.SetActive(true);
    }
    public void ToggleSpeetch()
    {
        if (image.enabled == true)
            DisableSpeetch();
        else
            ResetSpeetch();
    }

    //말풍선 끄기
    public void DisableSpeetch()
    {
        image.enabled = false;
        foreach (var each in listText)
        {
            each.gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.Subsystems;
using UnityEngine.UI;

public class write_409 : Page
{
    public RectTransform Example;

    List<RectTransform> Examples;
    List<Vector3> ExamplesStartPosition = new List<Vector3>();

    public RectTransform DragArea;

    List<RectTransform> DragAreas;

    public Button NextButton;

    public List<int> correctIndex;
    public List<int> answerIndex = new List<int>();
    IEnumerator startCoro()
    {
        yield return null;
        foreach (var each in Examples)
        {
            ExamplesStartPosition.Add(each.anchoredPosition);
        }
    }


    void Start()
    {
        foreach (var each in correctIndex)
        {
            answerIndex.Add(0);
        }
        NextButton.gameObject.SetActive(false);
        Examples = Example.GetComponentsInChildren<RectTransform>().ToList();
        Examples.Remove(Example);

        DragAreas = DragArea.GetComponentsInChildren<RectTransform>().ToList();
        DragAreas.Remove(DragArea);
        StartCoroutine(startCoro());
        int idx = 0;
        foreach (var each in Examples)
        {
            int b = idx;
            EventTrigger eventTrigger = each.gameObject.AddComponent<EventTrigger>();

            EventTrigger.Entry entry_PointerDown = new EventTrigger.Entry();
            entry_PointerDown.eventID = EventTriggerType.Drag;
            entry_PointerDown.callback.AddListener((data) => { OnDrag(each, (PointerEventData)data); });
            eventTrigger.triggers.Add(entry_PointerDown);

            EventTrigger.Entry entry_Drag = new EventTrigger.Entry();
            entry_Drag.eventID = EventTriggerType.EndDrag;
            entry_Drag.callback.AddListener((data) => { OnEndDrag(b, each, (PointerEventData)data); });
            eventTrigger.triggers.Add(entry_Drag);
            idx++;
        }

    }

    public void OnDrag(RectTransform tf, PointerEventData data)
    {
        tf.position = data.position;
    }
    public void OnEndDrag(int idx, RectTransform tf, PointerEventData data)
    {
        int rectidx = 0;
        foreach (var each in DragAreas)
        {
            Rect re = each.rect;
            re.position = (Vector2)each.position - new Vector2(re.width / 2f, re.height / 2f);
            if (re.Contains(tf.position))
            {
                //Stage03StoryManager.instance.Answers[rectidx] = tf.GetComponent<Text>().text;
                if (each.childCount > 0)
                {
                    var a = each.GetChild(0);
                    a.parent = tf.parent;
                    a.localPosition = Vector3.zero;
                }
                tf.parent = each;
                tf.localPosition = Vector3.zero;

                if (Example.childCount == 0)
                {
                    NextButton.gameObject.SetActive(true);


                }

                bool chk = true;
                int idx2 = 0;
                foreach (var each2 in DragAreas)
                {
                    if (each2.childCount == 0)
                    {
                        chk = false;
                        break;
                    }

                    if (each2.GetChild(0) != Examples[correctIndex[idx2]])
                    {
                        chk = false;
                        break;
                    }

                    idx2++;
                }
                if (chk == true)
                {
                    NextButton.interactable = true;
                }
                else
                    NextButton.interactable = false;

                return;
            }
            rectidx++;
        }
        tf.anchoredPosition = ExamplesStartPosition[idx];
    }


    private void Update()
    {

    }


    public override void OnResetPage()
    {
        base.OnResetPage();
    }

}

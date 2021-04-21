using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Game_DragSlot : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Game_4 game;

    public void OnBeginDrag(PointerEventData eventData)
    {
        for(int i = 0; i < game.dragImageP.childCount; i++)
        {
            if (this == game.dragImageP.GetChild(i).GetComponent<Game_DragSlot>())
                game.selectIndex = i + 1;
        }

        game.dragObject.gameObject.SetActive(true);
        var image = game.dragObject.transform.GetComponent<Image>();
        image.sprite = transform.GetComponent<Image>().sprite;
        image.color = new Color(1, 1, 1, 0.5f);
        game.dragObject.transform.GetComponent<RectTransform>().sizeDelta = (transform.GetComponent<RectTransform>().sizeDelta * 0.9f);
    }

    public void OnDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        game.dragObject.gameObject.SetActive(false);

        List<RaycastResult> results = new List<RaycastResult>();
        game.gr.Raycast(eventData, results);

        if (results.Count <= 0)
            game.dragObject.gameObject.SetActive(false);
        

        int findIndex = 0;
        for (int i = 0; i < results.Count; i++)
        {
            if (results[i].gameObject.GetComponent<Game_DropSlot>())
                findIndex = i;
        }

        for (int i = 0; i < game.dropImageP.childCount; i++)
        {
            if (results[findIndex].gameObject.GetComponent<Game_DropSlot>() == 
                game.dropImageP.GetChild(i).GetComponent<Game_DropSlot>())
            {
                if(game.dropIndex[i] == game.selectIndex)
                {
                    results[findIndex].gameObject.GetComponent<Game_DropSlot>().transform.GetComponent<Image>().sprite = game.dragObject.transform.GetComponent<Image>().sprite;
                    game.dropIndex[i] = -1;
                    game.CheckWin();
                }
                else
                {
                    game.remainNumber--;
                }


            }
        }


        game.dragObject.gameObject.SetActive(false);
    }
}

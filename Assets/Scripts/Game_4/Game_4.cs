using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Game_4 : Page
{
    public Transform dragImageP;
    public Transform dropImageP;

    private List<Sprite> sprites = new List<Sprite>();

    private int[] saveDropIndex;
    public int[] dropIndex;

    public Drag_4 dragObject;

    public GraphicRaycaster gr;

    public int selectIndex = 0;
    public int remainNumber = 20;

    public Text pageText = null;
    public GameObject hintObj = null;
    public Text remainText = null;
    public Text hint = null;
    public Text macaronCountText = null;
    public string[] hintTexts = null;
    public int curHintIndex = 2;
    public GameObject nextObj = null;
    public GameObject reGame = null;

    private void Start()
    {
        saveDropIndex = dropIndex.ToArray();
        for(int i = 0; i < dropImageP.childCount; i++)
        {
            sprites.Add(dropImageP.GetChild(i).GetComponent<Image>().sprite);
        }

        pageText.text = PageManager.Instance.problemPage.ToString() + " of 4";
        remainText.text = remainNumber.ToString();
        macaronCountText.text = PageManager.Instance.macaronCount.ToString();

    }

    public void HintOn()
    {
        if (curHintIndex <= -1)
            return;

        hint.transform.parent.gameObject.SetActive(true);
        hint.text = hintTexts[curHintIndex];
        hintObj.transform.GetChild(curHintIndex--).GetComponent<Image>().color = new Color(0.75f, 0.75f, 0.75f, 1f);

    }

    public void ResetGame()
    {
        reGame.SetActive(false);
        dropIndex = saveDropIndex;

        selectIndex = 0;
        remainNumber = 20;

        remainText.text = remainNumber.ToString();
        hint.transform.parent.gameObject.SetActive(false);
        for(int i = 0; i < hintObj.transform.childCount; i++)
            hintObj.transform.GetChild(i).GetComponent<Image>().color = Color.white;

        for(int i = 0; i < dragImageP.childCount; i++)
        {
            dragImageP.GetChild(i).GetComponent<Image>().color = Color.white;
        }
        for (int i = 0; i < dropImageP.childCount; i++)
        {
            dropImageP.GetChild(i).GetComponent<Image>().sprite = sprites[i];
        }

    }



    public void CheckWin()
    {
        bool isWin = true;
        for(int i = 0; i < dropIndex.Length; i++)
        {
            if (dropIndex[i] != -1)
                isWin = false;
        }
        if (!isWin)
            return;
        PageManager.Instance.problemPage++;
        PageManager.Instance.macaronCount += 3;
        nextObj.SetActive(true);
    }

}

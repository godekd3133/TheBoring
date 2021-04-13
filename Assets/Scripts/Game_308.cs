using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TapImageGame : Page
{
    public Text pageText = null;
    public Text macaronCount = null;
    public Text starCount = null;

    public GameObject hintObj = null;
    public GameObject realHintObj = null;
    public GameObject nextPageObj = null;

    public Button[] buttons = null;

    bool isActiveHint = false;

    bool isCardSelect = false;

    public override void ResetPage()
    {
        PageManager.Instance.problemPage++;
        starCount.text = PageManager.Instance.getStarCount.ToString();
        macaronCount.text = PageManager.Instance.macaronCount.ToString();
        pageText.text = PageManager.Instance.problemPage.ToString() + " of 10";
    }

    private void Start()
    {
        foreach(var button in buttons)
        {
            button.onClick.AddListener(() => {
                if (isCardSelect) return;
                isCardSelect = true;
                nextPageObj.SetActive(true);
                button.gameObject.SetActive(false); });
        }
    }

    public void ShowHint(bool isActive)
    {
        if (isActiveHint)
            return;

        hintObj.SetActive(isActive);
    }
    public void ShowHintObj(bool isActive)
    {
        isActiveHint = true;

        PageManager.Instance.macaronCount -= 1;
        macaronCount.text = PageManager.Instance.macaronCount.ToString();

        realHintObj.SetActive(isActive);
    }

    public void GetStar(int count)
    {
        if (isCardSelect)
            return;
        PageManager.Instance.getStarCount += count;
        starCount.text = PageManager.Instance.getStarCount.ToString();
    }
}


public class Game_308 : TapImageGame
{
}

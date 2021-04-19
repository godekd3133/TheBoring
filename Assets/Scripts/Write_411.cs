using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Write_411 : Page
{
    public List<Image> stars;

    public Sprite nonStar;
    public Sprite star;

    public GameObject NextButton;

    private void Start()
    {
        NextButton.SetActive(false);
    }

    public override void OnResetPage()
    {
        base.OnResetPage();
    }

    public void Star(int cnt)
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < cnt)
                stars[i].sprite = star;
            else
                stars[i].sprite = nonStar;
            NextButton.SetActive(true);
        }

    }

}

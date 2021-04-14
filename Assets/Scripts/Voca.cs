using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Voca : Page
{
    [Space(20)]
    public Sprite wordSprite;
    public string wordString;
    [Space(20)]

    public string Str01;
    public string Str02;
    public string Str03;

    [Space(30)]

    public Image wordImage;
    public Text wordText;



    public Button button01;
    public Button button02;
    public Button button03;

    public Text text01;
    public Text text02;
    public Text text03;





    void Start()
    {
        wordImage.sprite = wordSprite;
        wordText.text = wordString;

        text01.text = Str01;
        text02.text = Str02;
        text03.text = Str03;

        OnResetPage();

    }

    public override void OnResetPage()
    {
        base.OnResetPage();
        button01.gameObject.SetActive(true);
        button02.gameObject.SetActive(true);
        button03.gameObject.SetActive(true);

    }
}

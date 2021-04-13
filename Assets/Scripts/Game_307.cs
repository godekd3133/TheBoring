using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_307 : Page
{
    [SerializeField] GameObject guideObj = null;


    public void ShowGuide(bool isActive)
    {
        guideObj.SetActive(isActive);
    }
}

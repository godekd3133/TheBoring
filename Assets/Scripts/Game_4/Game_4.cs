using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_4 : Page
{
    public Transform dragImageP;
    public Transform dropImageP;
    
    public int[] dropIndex;

    public Drag_4 dragObject;

    public GraphicRaycaster gr;

    public int selectIndex = 0;
    public int remainNumber = 20;


    public void CheckWin()
    {
        bool isWin = true;
        for(int i = 0; i < dropIndex.Length; i++)
        {
            if (dropIndex[i] != -1)
                isWin = false;
        }
    }

}

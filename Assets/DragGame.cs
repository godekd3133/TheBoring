using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragGame : Page
{
    public Transform bingoBoard = null;
    public RectTransform rectTp = null;
    public List<Text> listText = null;
    public string text = null;

    public DragObject dragObject = null;

    private void Start()
    {
        string[] chars = text.Split(',');
        listText = bingoBoard.GetComponentsInChildren<Text>().ToList();
        for (int i = 0; i < listText.Count; i++)
        {
            listText[i].text = chars[i];
        }

    }


}

using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragGame : Page
{
    private int[] saveStart;
    private int[] saveEnd;


    public int[] collectStartIndex;
    public int[] collectEndIndex;
    public List<string> collectString;
    public List<Text> collectText;
    public GameObject collectTextParent;
    

    public int collectIndex = 0;

    public Transform bingoBoard = null;
    public List<Text> listText = null;
    public string text = null;
    public GraphicRaycaster gr;

    public DragObject dragObject = null;


    public GameObject hintParent;
    public GameObject hintObj;
    public string[] hintText;
    
    public int macaronIndex = 2;

    public int CountDown = 300;
    private int saveCountDown;
    public int resultPoint = 0;

    public Text countDownText;

    public Text macaronCountText;

    public Text pointText;

    public Text pageText;

    public GameObject DragObjectsParent;

    public Coroutine countDownCoroutine = null;
    public GameObject gameOverObj = null;

    public GameObject nextGameButtonObj = null;



    private void Start()
    {
        saveStart = collectStartIndex;
        saveEnd = collectEndIndex;
        saveCountDown = CountDown;

        collectIndex = collectStartIndex.Length;
        string[] chars = text.Split(',');
        listText = bingoBoard.GetComponentsInChildren<Text>().ToList();
        var listDragPoint = bingoBoard.GetComponentsInChildren<DragPoint>().ToList();
        collectText = collectTextParent.transform.GetComponentsInChildren<Text>().ToList();

        for(int i = 0; i < collectText.Count; i++)
        {
            collectText[i].text = collectString[i];
            collectText[i].color = Color.white;
        }

        for (int i = 0; i < listText.Count; i++)
        {
            listText[i].text = chars[i];
        }


        for (int i = 0; i < listDragPoint.Count; i++)
        {
            listDragPoint[i].index = i;
        }
        macaronCountText.text = PageManager.Instance.macaronCount.ToString();
        pageText.text = PageManager.Instance.problemPage.ToString() +" of " + "3";

        if (countDownCoroutine != null)
        {
            StopCoroutine(countDownCoroutine);
            countDownCoroutine = null;
        }

        countDownCoroutine = StartCoroutine(GameCountDown());


    }


    public void UseHint()
    {
        if (macaronIndex < 0)
            return;

        hintParent.transform.GetChild(macaronIndex).GetComponent<Image>().color = new Color(0.75f, 0.75f, 0.75f);
        hintObj.SetActive(true);
        hintObj.GetComponentInChildren<Text>().text = hintText[macaronIndex--];
    }

    IEnumerator GameCountDown()
    {
        countDownText.text = "0" + (CountDown / 60).ToString() + ":" + (CountDown % 60).ToString("D2");
        while (CountDown > 0)
        {
            yield return new WaitForSeconds(1f);
            CountDown--;
            countDownText.text = "0" + (CountDown / 60).ToString() + ":" + (CountDown % 60).ToString("D2");
        }
        gameOverObj.SetActive(true);
    }

    public void NextGame()
    {
        PageManager.Instance.macaronCount += resultPoint / 2;
        PageManager.Instance.problemPage++;

        PageManager.Instance.NextPage();
    }

    public void ReGame()
    {
        macaronIndex = 2;
        resultPoint = 0;
        CountDown = saveCountDown;
        pointText.text = "0";
        countDownText.text = "0" + (CountDown / 60).ToString() + ":" + (CountDown % 60).ToString("D2");
        hintObj.SetActive(false);
        gameOverObj.SetActive(false);

        for (int i = 0; i < hintParent.transform.childCount; i++)
            hintParent.transform.GetChild(i).GetComponent<Image>().color = Color.white;

        collectStartIndex = saveStart;
        collectEndIndex = saveEnd;

        for(int i = 0; i < DragObjectsParent.transform.childCount; i++)
        {
            Destroy(DragObjectsParent.transform.GetChild(i).gameObject);
        }

        Start();
    }

    public void CheckWin()
    {

        bool isWin = true;
        for(int i = 0; i < collectStartIndex.Length; i ++)
        {
            if (collectStartIndex[i] != -1)
                isWin = false;
        }

        if (!isWin)
            return;

        StopCoroutine(countDownCoroutine);
        countDownCoroutine = null;
        nextGameButtonObj.SetActive(true);


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GlobalInstance<T> : MonoBehaviour where T : GlobalInstance<T>
{
    public static T Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<T>();
            return instance;
        }
    }
    private static T instance = null;
}


public class PageManager : GlobalInstance<PageManager>
{
    public Transform canvas;
    public int currentPageIndex = 1;
    public int bookMarkIndex = 0;
    public int bookMarkCount = 4;
    public int[] bookMarkChangeIndex;


    public int problemPage = 0;
    public int macaronCount = 5;
    public int getStarCount = 0;

    public void PrevPage()
    {
        var oldTf = canvas.GetChild(bookMarkCount + (currentPageIndex));
        oldTf.gameObject.SetActive(false);

        var tf = canvas.GetChild(bookMarkCount + (--currentPageIndex));
        tf.gameObject.SetActive(true);
        tf.GetComponent<Page>().OnResetPage();

    }
    public void NextPage()
    {
        var oldTf = canvas.GetChild(bookMarkCount + (currentPageIndex));
        oldTf.gameObject.SetActive(false);

        var tf = canvas.GetChild(bookMarkCount + (++currentPageIndex));
        tf.gameObject.SetActive(true);
        tf.GetComponent<Page>().OnResetPage();

        for(int i = 0; i < bookMarkChangeIndex.Length; i++)
        {
            if(bookMarkChangeIndex[i] == (bookMarkCount + currentPageIndex))
            {
                var bookTf = canvas.GetChild(i);
                bookTf.gameObject.SetActive(true);

                var oldBookTf = canvas.GetChild(i - 1);
                oldBookTf.gameObject.SetActive(false);
            }
        }


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScene : MonoBehaviour
{
    int MaxStage;

    private void Start()
    {
        MaxStage = PlayerPrefs.GetInt("MaxStage", 1);

        //임시코드
        MaxStage = 2;
    }
    public void OnButtonClick()
    {
        if (MaxStage == 1)
            SceneManager.LoadScene("1stScene");

        else if (MaxStage == 2)
            SceneManager.LoadScene("2ndScene");

        else if (MaxStage == 3)
            SceneManager.LoadScene("3rdScene");

        else if (MaxStage == 4)
            SceneManager.LoadScene("4thScene");

    }
}

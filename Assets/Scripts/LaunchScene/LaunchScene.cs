using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LaunchScene : MonoBehaviour
{
    public Button startButton;

    int MaxStage;

    void Start()
    {
        MaxStage = PlayerPrefs.GetInt("MaxStage", 1);

        //임시코드
        MaxStage = 2;

        startButton.onClick.AddListener(OnClickStartButton);
    }

    public void OnClickStartButton()
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LaunchScene : MonoBehaviour
{
    public Button startButton;


    void Start()
    {
        startButton.onClick.AddListener(OnClickStartButton);
    }

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("HomeScene");

    }


}

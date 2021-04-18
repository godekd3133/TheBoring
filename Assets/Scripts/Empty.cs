using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Empty : Page
{
    public void GoTitle()
    {

        SceneManager.LoadScene("LaunchScene");
    }

    public void GoHome03()
    {
        SceneManager.LoadScene("HomeScene03");

    }
}

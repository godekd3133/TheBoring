using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Write_413 : Page
{
    public float timeLimit;
    public Image Gauge;
    public GameObject gameOver;

    public InputField InputField;
    public string correctAnswer;

    public GameObject Fix;
    public GameObject ClearMessage;

    public bool success;
    public bool isFailed = false;

    [HideInInspector] public float currentTimer;

    public void OnSuccess()
    {
        Fix.SetActive(true);
        success = true;
    }

    public override void OnResetPage()
    {
        base.OnResetPage();
        currentTimer = timeLimit;
        success = false;
        InputField.text = "";
        Fix.SetActive(false);
        isFailed = false;

        gameOver.SetActive(false);
        ClearMessage.SetActive(false);
        InputField.interactable = true;
    }

    public void Restart()
    {
        currentTimer = timeLimit;
        success = false;
        InputField.text = "";
        Fix.SetActive(false);

        gameOver.SetActive(false);
        ClearMessage.SetActive(false);
        InputField.interactable = true;
    }


    public void ChkInput()
    {
        if (InputField.text == correctAnswer)
        {
            InputField.interactable = false;
            ClearMessage.SetActive(true);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        OnResetPage();
    }

    // Update is called once per frame
    void Update()
    {
        if (success == false)
        {
            if (currentTimer < 0f)
            {
                if (isFailed == true)
                {
                    OnSuccess();
                }
                else
                {
                    isFailed = true;
                    gameOver.SetActive(true);

                }
            }
            else
                currentTimer -= Time.deltaTime;

            Gauge.fillAmount = currentTimer / timeLimit;
        }
    }

    public void OnHintButtonDown()
    {

    }
}

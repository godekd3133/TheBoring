﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Write : Page
{
    public RectTransform answer;

    public Text macarongText;

    public Button chkButton;

    public GameObject hintImage;

    public List<string> correctAnswers = new List<string>();

    private List<InputField> listAnswers = new List<InputField>();

    private void Awake()
    {
        listAnswers = GetComponentsInChildren<InputField>().ToList();
    }

    private void Start()
    {
        hintImage.SetActive(false);
    }
    public void OnHint()
    {
        if (PageManager.Instance.macaronCount >= 1)
        {
            hintImage.SetActive(true);
            PageManager.Instance.macaronCount--;
        }
    }

    private void Update()
    {
        macarongText.text = PageManager.Instance.macaronCount.ToString();
        bool chk = true;
        foreach (var each in listAnswers)
        {
            if (each.text == "")
            {
                chk = false;
                break;
            }
            else
            {
                chk = true;
            }
        }

        if (chk == true)
        {
            chkButton.interactable = true;
        }
        else chkButton.interactable = false;

    }

    public void OnCheckButtonDown()
    {
        StartCoroutine(buttonShake(0.1f));
    }

    public override void OnResetPage()
    {
        base.OnResetPage();
    }

    IEnumerator buttonShake(float duraction)
    {
        float timer = 0f;

        Vector3 position = chkButton.transform.position;
        while (timer < duraction)
        {
            timer += Time.deltaTime;
            chkButton.transform.position = position + new Vector3(Random.insideUnitCircle.x, Random.insideUnitCircle.y, 0f) * 2.5f;
            yield return null;
        }
        chkButton.transform.position = position;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WriteChapter : MonoBehaviour
{
    public float time = 30f;
    public Image timerBar;
    public int cpu = 0;
    public int user = 0;
    public Text cpuText;
    public Text userText;
    public int stage = 0;
    public Text[] examples;
    public string[] texts;
    public string[] answers;
    public Holder[] holds;
    public int hintCount = 0;
    public Text hintText;
    public TMPro.TextMeshProUGUI amount;
    public string[] hints;
    public Text stageText;
    public GameObject endingPopup;
    // Start is called before the first frame update
    void Start()
    {
        UpdateInit();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timerBar.fillAmount = time / 30f;
        if(time <= 0)
        {
            CpuWin();
        }
    }

    public void UpdateInit()
    {
        if (hints.Length <= stage)
        {
            endingPopup.SetActive(true);
            return;
        }
        for(var i = 0; i < examples.Length; i++)
        {
            examples[i].text = "= " + texts[stage].Split(',')[i];
            if(holds[i].dragable != null)
                holds[i].dragable.Reset();
        }
        hintCount = 0;
        amount.text = hints[stage].Split(',').Length + "";
        stageText.text = (stage + 1) + " of "+ hints.Length;
    }

    public void SetHint()
    {
        if (hints[stage].Split(',').Length <= hintCount) return;
        hintText.text = hints[stage].Split(',')[hintCount++];
        amount.text = (hints[stage].Split(',').Length - hintCount) + "";
    }

    public void OnBell()
    {
        foreach(var hold in holds)
        {
            if (hold.dragable == null) return;
        }
        var value = string.Join(",", holds.Select(i => i.dragable.index.ToString()));
        if (answers[stage] == value)
        {
            user += 1;
            userText.text = user.ToString();
            stage += 1;
            UpdateInit();
            time = 30f;
        }
        else
        {
            for (var i = 0; i < holds.Length; i++)
            {
                if (holds[i].dragable != null)
                    holds[i].dragable.Reset();
            }
        }
    }

    private void CpuWin()
    {
        cpu += 1;
        cpuText.text = cpu.ToString();
        time = 30f;
        stage += 1;
        UpdateInit();
    }
}

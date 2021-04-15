using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Story : Page
{
    public RectTransform problems;

    public Button nextButton;

    private List<StoryProblem> listProblems = new List<StoryProblem>();

    private void Awake()
    {
        listProblems = problems.GetComponentsInChildren<StoryProblem>().ToList();

        foreach (var each in listProblems)
        {
            each.handleStory = this;
        }
    }



    void Start()
    {
        nextButton.gameObject.SetActive(false);
    }

    void Update()
    {
        bool chk = true;
        foreach (var each in listProblems)
        {
            chk = each.isClear;

            if (chk == false)
                break;
        }

        if (chk == true)
        {
            nextButton.gameObject.SetActive(true);
        }

    }
}

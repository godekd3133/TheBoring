using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StoryProblem_ChooseSolution : MonoBehaviour
{
    public RectTransform solution;

    public GameObject Correct;
    public GameObject InCorrect;

    private List<Button> solutions;

    public int corrctSolutionIdx;

    void Start()
    {
        Correct.SetActive(false);
        InCorrect.SetActive(false);

        solutions = solution.GetComponentsInChildren<Button>().ToList();

        for (int i = 0; i < solutions.Count; i++)
        {
            if (i == corrctSolutionIdx)
                solutions[i].onClick.AddListener(OnClickCorrectSolution);
            else
                solutions[i].onClick.AddListener(OnClickIncorrectSoulution);
        }
    }

    public void OnClickCorrectSolution()
    {
        print("딩동댕");
        Correct.SetActive(true);

    }
    public void OnClickIncorrectSoulution()
    {
        print("땡");
        InCorrect.SetActive(true);
    }


    void Update()
    {

    }
}

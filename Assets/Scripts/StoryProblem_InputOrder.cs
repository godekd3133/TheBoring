using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class StoryProblem_InputOrder : StoryProblem
{
    public RectTransform inputField;

    public List<GameObject> Correct;

    private List<InputField> inputFields;
    public List<int> answerOrder;


    void Start()
    {
        foreach (var each in Correct)
            each.SetActive(false);


        inputFields = inputField.GetComponentsInChildren<InputField>().ToList();

        for (int i = 0; i < inputFields.Count; i++)
        {
            int cnt = i;
            inputFields[i].onEndEdit.AddListener((string str) => OnEndEdit(cnt, str));
        }
    }

    public void OnEndEdit(int idx, string str)
    {
        if (int.Parse(str) == answerOrder[idx])
        {
            //정답일때
            inputFields[idx].interactable = false;
            Correct[idx].SetActive(true);

            bool chk = true;
            foreach (var each in Correct)
            {
                if (each.active)
                    chk = true;
                else
                {
                    chk = false;
                    break;
                }
            }


            if (chk == true)
            {
                isClear = true;
            }
        }
        else
        {
            StartCoroutine(Shake(inputFields[idx].gameObject, 0.15f));
        }


    }

    IEnumerator Shake(GameObject obj, float duraction)
    {
        float timer = 0f;

        Vector3 position = obj.transform.position;
        while (timer < duraction)
        {
            timer += Time.deltaTime;
            obj.transform.position = position + new Vector3(Random.insideUnitCircle.x, Random.insideUnitCircle.y, 0f) * 2.5f;
            yield return null;
        }
        obj.transform.position = position;
    }



    public override bool CheckSolution()
    {
        return isClear;
    }
}

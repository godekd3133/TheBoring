using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CardGame : MonoBehaviour
{
    public int life = 40;
    public TMPro.TextMeshProUGUI lifeText;
    public TMPro.TextMeshProUGUI hintText;
    public int[] images;
    public int[] texts;
    private List<int> set = new List<int>();
    public GameObject nextChapter;
    public int correctCount = 0;
    public int hintCount = 0;
    public string[] hints;
    public TextMeshProUGUI hintAmount;
    public TextMeshProUGUI stageText;
    public int stage;
    // Start is called before the first frame update
    void Start()
    {
        lifeText.text = life + "";
        hintAmount.text = hints.Length + "";
        hintText.text = "잘 모르겠으면 날 탭해 봐!";
        stageText.text = stage + " of " + 3;
    }

    public void SetHint()
    {
        if (!gameObject.activeSelf) return;
        if (hints.Length <= hintCount) return;
        hintText.text = hints[hintCount++];
        hintAmount.text = (hints.Length - hintCount) + "";
    }

    public void SetCard(int index)
    {
        set.Add(index);
        life -= 1;
        lifeText.text = life + "";
        if(set.Count >= 2)
        {
            var first = set[0];
            var i = images.ToList().IndexOf(first);
            var correct = true;
            if(i >= 0)
            {
                correct = texts[i] == set[1];
            }
            else
            {
                i = texts.ToList().IndexOf(first);
                correct = images[i] == set[1];
            }
            if (!correct)
            {
                foreach(var item in set) {
                    transform.GetChild(item-1).GetComponent<Card>().Reset();
                }
            }
            else
            {
                correctCount += 1;
                if(correctCount >= 5)
                {
                    if(nextChapter == null)
                    {
                        SceneManager.LoadScene("Write");
                    }
                    nextChapter.gameObject.SetActive(true);
                    gameObject.SetActive(false);
                }

            }
            set.Clear();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

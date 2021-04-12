using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class Correction : MonoBehaviour
{
    public int answer;
    public GameObject correctionMark;
    public GameObject missText;
    public Button[] buttons;
    public bool activate = false;
    public Correction[] corrections;
    public GameObject activatedButton;
    // Start is called before the first frame update
    void Start()
    {
        correctionMark.SetActive(false);
        missText.SetActive(false);
        for (var i = 0; i < buttons.Length; i++)
        {
            var item = i;
            buttons[i].onClick.AddListener(() =>
            {
                if (activate) return;
                correctionMark.SetActive(item == answer);
                correctionMark.GetComponent<RectTransform>().anchoredPosition = buttons[item].GetComponent<RectTransform>().anchoredPosition;
                missText.SetActive(item != answer);
                if(item == answer)
                {
                    activate = true;
                    if(corrections.Select(a => a.activate).All(a => a))
                    {
                        activatedButton.SetActive(true);
                    }
                }
            });
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

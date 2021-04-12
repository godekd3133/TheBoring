using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Voca : MonoBehaviour
{
    public GameObject 알렉스대사모음;

    public GameObject[] 알렉스대사_1차시;

    public GameObject[] 단어모음_1차시;

    public GameObject 알렉스설명문;

    public int index = 0;

    public static int count = 0;

    public int 몇번째단어 = 0;

    public GameObject 다음화살표오브젝트;

    public GameObject 이전화살표오브젝트;

    public bool 처음설명문 = true;

    void Start()
    {
        알렉스대사모음.SetActive(true);

    }

    private void Update()
    {
        if(몇번째단어 == 0)
        {
            if(count == 3)
            {
                다음화살표오브젝트.SetActive(true);
            }
        }
        else
        {
            if (count == 3)
            {
                이전화살표오브젝트.SetActive(true);
                다음화살표오브젝트.SetActive(true);

            }
        }
        
    }

    public void 말풍선터치()
    {
        if (index == 2)
        {
            알렉스대사모음.SetActive(false);
        }
        else
        {
            알렉스대사_1차시[index].SetActive(false);
            index++;
            알렉스대사_1차시[index].SetActive(true);
        }
    }

    public void 다음화살표()
    {
        if(몇번째단어 == 7)
        {
            SceneManager.LoadScene("Story");
            
        }
        if(처음설명문 == true)
        {
            알렉스대사_1차시[0].SetActive(false);
            알렉스대사_1차시[1].SetActive(false);
            알렉스대사_1차시[2].SetActive(false);
            알렉스설명문.SetActive(true);
            처음설명문 = false;
        }
        count = 0;
        단어모음_1차시[몇번째단어].SetActive(false);
        몇번째단어++;
        단어모음_1차시[몇번째단어].SetActive(true);
        단어모음_1차시[몇번째단어].transform.GetChild(3).gameObject.SetActive(true);
        단어모음_1차시[몇번째단어].transform.GetChild(5).gameObject.SetActive(true);
        단어모음_1차시[몇번째단어].transform.GetChild(7).gameObject.SetActive(true);

        이전화살표오브젝트.SetActive(false);
        다음화살표오브젝트.SetActive(false);


    }

    public void 이전화살표()
    {
        count = 0;

        단어모음_1차시[몇번째단어].SetActive(false);
        몇번째단어--;
        단어모음_1차시[몇번째단어].SetActive(true);
        단어모음_1차시[몇번째단어].transform.GetChild(3).gameObject.SetActive(true);
        단어모음_1차시[몇번째단어].transform.GetChild(5).gameObject.SetActive(true);
        단어모음_1차시[몇번째단어].transform.GetChild(7).gameObject.SetActive(true);
        이전화살표오브젝트.SetActive(false);
        다음화살표오브젝트.SetActive(false);

    }

    public void 삭제하기()
    {
        알렉스설명문.SetActive(false);
    }


}

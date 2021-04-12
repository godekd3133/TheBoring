using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public GameObject 알렉스대사모음;

    public GameObject[] 알렉스대사_1차시;

    public GameObject 설명문;

    public GameObject 누나대사;

    public GameObject 괴물대사;

    public int index = 0;


    // Start is called before the first frame update
    void Start()
    {
        알렉스대사모음.SetActive(true);
        
    }
    
    public void 보카로이동()
    {
        SceneManager.LoadScene("Voca");
    }

    public void 누나터치()
    {
        if(누나대사.activeSelf == true)
        {
            누나대사.SetActive(false);
        }
        else
        {
            누나대사.SetActive(true);
        }
    }


    public void 괴물터치()
    {
        if (괴물대사.activeSelf == true)
        {
            괴물대사.SetActive(false);
        }
        else
        {
            괴물대사.SetActive(true);
        }
    }

    public void 말풍선터치()
    {
        if(index == 4)
        {
            알렉스대사모음.SetActive(false);
            설명문.SetActive(true);
        }

        알렉스대사_1차시[index].SetActive(false);
        index++;
        알렉스대사_1차시[index].SetActive(true);
        

    }

    public void 알렉스터치()
    {
        index = 0;
        알렉스대사_1차시[index].SetActive(true);
        알렉스대사모음.SetActive(true);

    }


}

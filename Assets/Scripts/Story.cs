using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour
{
    public GameObject 알렉스설명문;
    public GameObject[] classes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void 삭제하기()
    {
        Debug.Log("클릭");
        알렉스설명문.SetActive(false);
    }

    public void 게임하러가기()
    {
        Game.게임_차시수 = 1;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answer : MonoBehaviour
{

    public void 정답공개()
    {
        Debug.Log(this.gameObject.name);
        this.gameObject.SetActive(false);
        Voca.count++;

    }


}

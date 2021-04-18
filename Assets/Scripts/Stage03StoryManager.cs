using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage03StoryManager : MonoBehaviour
{
    public static Stage03StoryManager instance;
    private void Awake()
    {
        instance = this;
    }
    public List<string> Answers = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 100; i++)
            Answers.Add("");
    }

    // Update is called once per frame
    void Update()
    {

    }
}

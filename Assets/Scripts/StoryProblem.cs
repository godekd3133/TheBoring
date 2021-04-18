using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StoryProblem : MonoBehaviour
{
    [HideInInspector] public Story handleStory = null;
    //정답인지 확인
    public bool isClear = false;

    //채점하는 함수
    public abstract bool CheckSolution();

}

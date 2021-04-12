using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneUIAdmin : MonoBehaviour
{
    [HideInInspector] public Scene CurrentScene;
    [ReadOnly(true)] public SceneUI UIScenePrefab;
    [ReadOnly] public SceneUI CurrentActiveUI;

    public void OnSceneFixedUpdate()
    {
        CurrentActiveUI.OnSceneFixedUpdate();
    }

    public void OnSceneLateUpdate()
    {
        CurrentActiveUI.OnSceneLateUpdate();
    }

    private void Awake()
    {
        CurrentScene = SceneManager.instance.GetCurrentActiveScene<Scene>();

        CurrentActiveUI = Instantiate(UIScenePrefab.gameObject, transform).GetComponent<SceneUI>();

        CurrentActiveUI.ManagedAdmin = this;
    }

    public void OnSceneLoad()
    {
        CurrentActiveUI.OnSceneLoad();
    }

    public void OnSceneUnload()
    {
        CurrentActiveUI.OnSceneUnload();

        Destroy(CurrentActiveUI.gameObject);
    }

    public void OnSceneUpdate()
    {
        CurrentActiveUI.OnSceneUpdate();
    }
}

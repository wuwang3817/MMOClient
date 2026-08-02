//资源加载服务
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResService : ILogic
{
    //更新场景加载进度回调
    private Action UpdateSceneLoadingProgress;
    public void Init()
    {
        this.Log("Resources Service initialized");
    }

    public void Tick()
    {
        UpdateSceneLoadingProgress?.Invoke();
    }

    public void UnInit()
    {
        this.Log("Resources Service uninitialized");
    }

    /// <summary>
    /// 异步场景加载
    /// </summary>
    /// <param name="sceneName"></param>
    /// <param name="loadingProgress"></param>
    /// <param name="loadDone"></param>
    public void LoadSceneAsync(string sceneName,Action<float> loadingProgress,Action loadDone)
    {
        if (sceneName == SceneManager.GetActiveScene().name)
        {
            loadingProgress?.Invoke(1f);
            loadDone?.Invoke();
        }
        else
        {
            AsyncOperation ao = SceneManager.LoadSceneAsync(sceneName);
            UpdateSceneLoadingProgress=() =>
            {
                loadingProgress?.Invoke(ao.progress);
                if(ao.progress>=1.0f)
                {
                    loadDone?.Invoke();
                    UpdateSceneLoadingProgress = null;
                }
            };
        }
        loadDone?.Invoke();
    }
}
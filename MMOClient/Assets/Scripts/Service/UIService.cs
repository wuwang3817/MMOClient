using System.Collections.Generic;
//UI管理服务
public class UIService:ILogic
{
    private Root root;
    private LoadingWindow loadingWindow;
    private readonly Dictionary<UIWindow, WindowRoot> windowDic = new Dictionary<UIWindow, WindowRoot>();
    public void Init()
    {
        root=Root.Instance;
        //Top
        loadingWindow =root.transform.Find("Canvas/LoadingWindow").GetComponent<LoadingWindow>();
        windowDic.Add(UIWindow.Loading, loadingWindow);

        this.Log("UI Service initialized");
    }

    public void Tick()
    {
    }

    public void UnInit()
    {
        this.Log("UI Service uninitialized");
    }
    /// <summary>
    /// 设置加载进度窗口
    /// </summary>
    /// <param name="percent"></param>
    /// <param name="state"></param>
    public void SetLoading(int percent,bool state=true)
    {
        loadingWindow.SetProgress(percent, state);
    }
}
//UI管理服务
public class UIService:ILogic
{
    public void Init()
    {
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
    /// <param name="pct"></param>
    /// <param name="state"></param>
    public void SetLoading(int pct,bool state=true)
    {
        
    }
}
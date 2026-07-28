//UI管理服务
public class UIService:ILogic
{
    public void Init()
    {
        this.Log("UI Service initialized");
    }

    public void Tick()
    {
        throw new System.NotImplementedException();
    }

    public void UnInit()
    {
        this.Log("UI Service uninitialized");
    }
}
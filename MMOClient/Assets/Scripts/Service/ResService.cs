//资源加载服务
public class ResService : ILogic
{
    public void Init()
    {
        this.Log("Resources Service initialized");
    }

    public void Tick()
    {
        throw new System.NotImplementedException();
    }

    public void UnInit()
    {
        this.Log("Resources Service uninitialized");
    }
}
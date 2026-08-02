//网络服务
public class NetService : ILogic
{
    public void Init()
    {
        this.Log("Network Service initialized");
    }
    public void Tick()
    {
    }
    public void UnInit()
    {
        this.Log("Network Service uninitialized");
    }

    //连接登录服务器
    public void ConnectToLogin()
    {

    }

}
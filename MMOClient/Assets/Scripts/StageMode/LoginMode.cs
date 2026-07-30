//登录验证模式
public class LoginMode : BaseMode
{
    public LoginMode() : base(PlayMode.Login)
    {
        
    }
    public override void Enter()
    {
        base.Enter();
        //连接login服务器
        root.NetService.ConnectToLogin();
    }
    public override void Update()
    {
        
    }
    public override void Exit()
    {
    }
}
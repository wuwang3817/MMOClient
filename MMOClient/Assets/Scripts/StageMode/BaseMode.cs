public enum PlayMode
{
    None,
    Login,//登录模式，无gameworld承载
    Create,//角色创建模式，无gameworld承载
    Major,//主城模式（主要是客户端NPC任务，社交平台，技能效果等表现）
    Wild,//野外模式（野外刷怪，采集材料等任务）
    Single,//单人副本模式
    Multiple,//多人组队模式
    Activity,//定时运营活动，世界Boss战，多少人一组，刷伤害比排行拿奖励
    Guild,//工会战，拿工会成员玩家数据站位PK
    Marriage,//结婚场景模式
    Fishing,//钓鱼模式
    Concert//演奏模式
}
//游戏玩法模式基类
public abstract class BaseMode
{
    protected Root root;
    protected PlayMode gameMode=PlayMode.None;
    public BaseMode(PlayMode modeEnum)
    {
        root = Root.Instance;
        gameMode =modeEnum;
    }
    public virtual void Enter()
    {
        
    }

    public abstract void Update();
    public abstract void Exit();
}
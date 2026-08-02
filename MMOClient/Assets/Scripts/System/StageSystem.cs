using System;
using Protocol;
//关卡加载系统
public class StageSystem : ILogic
{
    private Root root;
    private int currentstageID;
    private UIService UIService;
    private ResService resService;
    private Action loadingStageDone;
    public int CurrentStageID 
    {
        get => currentstageID;
    }
    public void Init()
    {
        
        root=Root.Instance;
        resService=new ResService();
        UIService=new UIService();
    }
    /// <summary>
    /// 当前关卡配置
    /// </summary>
    StageConfig config;
    public void Tick()
    {
    }

    public void UnInit()
    {
    }

    //加载游戏关卡
    public void LoadGameStage(int stageId,Action loadStageDone)
    {
        currentstageID=stageId;
        loadingStageDone=loadStageDone;
        config =XlsConfigTool.GetStageConfig(stageId);
        if(config.isGhost)
        {
            //镜像场景地图：水波屏幕特效过度
            this.LogGreen("水波特效过度");
        }
        else
        {
            UIService.SetLoading(0,true); 
        }
        LoadScene(config.sceneName);
    }
    private void LoadScene(string sceneName)
    {
        resService.LoadSceneAsync(sceneName,(progress)=>
        {
            UpdateLoadingProgress(progress);
        },()=>
        {
            UpdateLoadingProgress(1f);
        });
    }
    private void UpdateLoadingProgress(float progress)
    {
        if(progress==1f)
        {
            loadingStageDone?.Invoke();
            loadingStageDone=null;
        }
        else
        {
            if(loadingStageDone!=null&&!config.isGhost)
            {
                UIService.SetLoading((int)(progress*100));
            }
        }
    }
}

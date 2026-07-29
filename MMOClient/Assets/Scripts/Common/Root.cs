using PEUtils;
using UnityEngine;
using System.Collections.Generic;


public class Root : Singleton<Root>
{
    [SerializeField] private Transform uiRoot;
    
    private List<ILogic> Services=new List<ILogic>();
    private TimerService TimerService;
    private ResService ResService;
    private UIService UIService;
    void Start()
    {
        LogConfig config = new()
        {
            enableLog = true,
            logPrefix = "",
            enableTime = true,
            logSeparate = ">",
            enableThreadID = true,
            enableTrace = true,
            enableSave = true,
            enableCover = true,
            saveName = "MMOClientLog.txt",
            loggerEnum = LoggerType.Unity,
        };
        Application.targetFrameRate = 60;
        DontDestroyOnLoad(this);
        if (uiRoot == null)
        {
            uiRoot = transform.Find("Canvas");
        }

        for (int i = 0; i < uiRoot.childCount; i++)
        {
            uiRoot.GetChild(i).gameObject.SetActive(false);
        }
            
        PELog.InitSettings(config);
        this.Log("游戏开始");
        TimerService = new TimerService();
        Services.Add(TimerService);
        ResService = new ResService();
        Services.Add(ResService);
        UIService = new UIService();
        Services.Add(UIService);
        for (int i = 0; i < Services.Count; i++)
        {
            Services[i].Init();
        }

        // 初始化状态机
        fsm.Add(PlayMode.Login, new LoginMode());
        fsm.Add(PlayMode.Create, new CreateMode());
        fsm.Add(PlayMode.Major, new MajorMode());
        fsm.Add(PlayMode.Wild, new WildMode());

    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Services.Count; i++)
        {
            Services[i].Tick();
        }
    }
    private void OnApplicationQuit()
    {
        for (int i = Services.Count-1; i >=0; i--)
        {
            Services[i].UnInit();
        }
    }

    readonly Dictionary<PlayMode, BaseMode> fsm = new Dictionary<PlayMode, BaseMode>();
    private PlayMode currentMode= PlayMode.None;
    /// <summary>
    /// 进入目标游戏模式
    /// </summary>
    /// <param name="targetMode"></param>
    public void EnterGameMode(PlayMode targetMode)
    {
        if(fsm.ContainsKey(targetMode))
        {
            fsm[targetMode].Exit();
        }
        fsm[targetMode].Enter();
        currentMode = targetMode;
    }
    /// <summary>
    /// 退出当前游戏模式
    /// </summary>
    public void ExitGameMode()
    {
        if(currentMode!=PlayMode.None)
        {
            fsm[currentMode].Exit();
            currentMode = PlayMode.None;
        }
    }
}

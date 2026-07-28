using System;
using PEUtils;
using UnityEngine;
using System.Collections.Generic;


public class PERoot : MonoBehaviour
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
}

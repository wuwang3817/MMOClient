using UnityEngine;
using PEUtils;
public class PERoot : MonoBehaviour
{
    // Start is called before the first frame update
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
        PELog.InitSettings(config);
        this.Log("游戏开始");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

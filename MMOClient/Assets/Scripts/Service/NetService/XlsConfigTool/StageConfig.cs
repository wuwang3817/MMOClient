using UnityEditor.SceneManagement;

namespace Protocol
{
    public class StageConfig
    {
        public int stageID;
        public string stageName;
        public bool isGhost;
        public string sceneName;
        public PlayMode playMode;
    }
    public class XlsConfigTool
    {
        public static StageConfig GetStageConfig(int stageID)
        {
            return stageID switch
            {
                1=>new StageConfig
                {
                    stageID=1,
                    stageName="账号登陆",
                    sceneName="001_Login",
                    playMode=PlayMode.Login,
                },
                2=>new StageConfig
                {
                    stageID=2,
                    stageName="创建角色",
                    sceneName="002_Create",
                    playMode=PlayMode.Create,
                },
                _=>null,
            };
        }
    }
}
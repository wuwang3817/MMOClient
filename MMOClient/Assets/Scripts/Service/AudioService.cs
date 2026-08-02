using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//声音管理系统
public class AudioService : ILogic
{
    private Root root;
    private ResService resService;

    public bool TurnOnVoic = true;
    private AudioSource UIAudio;
    private AudioSource BackgroundAudio;
    public void Init()
    {
        root = Root.Instance;
        resService = root.ResService;
        UIAudio = root.transform.Find("UIAudio").GetComponent<AudioSource>();
        BackgroundAudio = root.transform.Find("BackgroundAudio").GetComponent<AudioSource>();
        
        this.Log("AudioService Init");
    }

    public void Tick()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            TurnOnVoic = !TurnOnVoic;
        }
    }

    public void UnInit()
    {
        this.Log("AudioService UnInit");
    }

}

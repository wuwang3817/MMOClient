using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//关卡进度切换显示
public class LoadingWindow : WindowRoot
{
    public Image ProgressImage;
    public Text ProgressText;
    protected override void InitWindow()
    {
        base.InitWindow();
        ProgressImage.fillAmount = 0;
        ProgressText.text = "0%";
    }

    protected override void UnInitWindow()
    {
        base.UnInitWindow();
        ProgressImage.fillAmount = 0;
        ProgressText.text = "0%";
    }

    public void SetProgress(int percent,bool state=true)
    {
        SetWindowState(state);
        ProgressImage.fillAmount = percent*1.0f / 100f;
        ProgressText.text = $"{percent}%";
    }
}

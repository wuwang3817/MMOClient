using System;
using PETimer;
public class TimerService : ILogic
{
    readonly TickTimer timer = new(0, false);
    public void Init()
    {
        timer.LogFunc=this.Log;
        timer.WarnFunc=this.Warn;
        timer.ErrorFunc=this.Error;
        this.Log("Timer Service initialized");
    }

    public void Tick()
    {
        timer.UpdateTask();
    }

    public void UnInit()
    {
        this.Log("Timer Service uninitialized");
    }

    public int AddTask(uint delay, Action<int> taskCB, Action<int> cancelCB = null, int count = 1)
    {
        return timer.AddTask(delay, taskCB, cancelCB, count);
    }

    public bool DeleteTask(int taskID)
    {
        return timer.DeleteTask(taskID);
    }
}

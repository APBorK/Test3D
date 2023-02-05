using System;

public class EventSistem
{
    public static Action OnKillBot;
    public static Action<float> OnMovePlayer;
    public static Action<float> OnKillBotPoint;
    public static Action<float> OnMovePlayerDistanse;

    public static void SendKillBot()
    {
        if (OnKillBot != null)
        {
            OnKillBot.Invoke();
        }
    }
    
    public static void SendKillBotPoint(float point)
    {
        if (OnKillBotPoint != null)
        {
            OnKillBotPoint.Invoke(point);
        }
    }
    
    public static void SendMovePlayer(float distanse)
    {
        if (OnMovePlayer != null)
        {
            OnMovePlayer.Invoke(distanse);
        }
    }
    
    public static void SendMovePlayerDistanse(float distanse)
    {
        if (OnMovePlayerDistanse != null)
        {
            OnMovePlayerDistanse.Invoke(distanse);
        }
    }
}

using System;

public class EventSistem
{
    public static Action OnKillBot;
    public static Action<float> OnMovePlayer;

    public static void SendKillBot()
    {
        if (OnKillBot != null)
        {
            OnKillBot.Invoke();
        }
    }

    public static void SendMovePlayer(float distanse)
    {
        if (OnMovePlayer != null)
        {
            OnMovePlayer.Invoke(distanse);
        }
    }
}

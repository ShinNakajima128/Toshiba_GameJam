using System;
public class EventManager 
{
    public static Action OnGameStart;
    public static Action OnGameEnd;
    public static void GameStart()
    {
        OnGameStart?.Invoke();
    }
    public static void GameEnd()
    {
        OnGameEnd?.Invoke();
    }
}

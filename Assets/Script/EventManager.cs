using System;
public class EventManager 
{
    public static event Action OnGameStart;
    public static event Action OnGameEnd;
    public static event Action<int> OnGetScore; 
    public static event Action<float, float> OnHPEvent;
    public static event Action<float, float> OnEPEvent;
    public static event Action<float> OnDifChangeEvent;

    public static void GameStart()
    {
        OnGameStart?.Invoke();
    }
    public static void GameEnd()
    {
        OnGameEnd?.Invoke();
    }
    public static void GetScore(int score)
    {
        OnGetScore?.Invoke(score);
    }

    public static void HPEvent(float currentValue, float maxValue)
    {
        OnHPEvent?.Invoke(currentValue, maxValue);
    }
    public static void EPEvent(float currentValue, float maxValue)
    {
        OnEPEvent?.Invoke(currentValue, maxValue);
    }

    public static void DifChangeEvent(float value)
    {
        OnDifChangeEvent?.Invoke(value);
    }


}

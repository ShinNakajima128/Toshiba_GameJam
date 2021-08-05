using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum DifficultyState
{
    easy,
    Normal,
    Hard,
    VeryHard,
    Pirate
}

public class ProgressManager : MonoBehaviour
{
    [SerializeField] Text m_difficulty = default;
    [SerializeField] Slider m_progressGauge = default;
    DifficultyState difficultyState;
    DifficultyState m_currentState;
    float progressValue = 0;
    bool isMaxed = false;

    void Update()
    {
        if (GameManager.Instance.GetInGame && !isMaxed)
        {
            progressValue += Time.deltaTime * GameManager.Instance.DashSpeed;
            m_progressGauge.value = progressValue;

            if (progressValue >= 0 && progressValue < 50)
            {
                difficultyState = DifficultyState.easy;
            }
            else if (progressValue >= 50 && progressValue < 100)
            {
                difficultyState = DifficultyState.Normal;
            }
            else if (progressValue >= 100 && progressValue < 150)
            {
                difficultyState = DifficultyState.Hard;
            }
            else if (progressValue >= 150 && progressValue < 200)
            {
                difficultyState = DifficultyState.VeryHard;
            }
            else if (progressValue >= 200 && progressValue < 250)
            {
                difficultyState = DifficultyState.Pirate;
            }
            else if (progressValue >= 250)
            {
                isMaxed = true;
            }
        }
        if (m_currentState != difficultyState)
        {
            switch (difficultyState)
            {
                case DifficultyState.easy:
                    m_difficulty.text = "EASY";
                    break;
                case DifficultyState.Normal:
                    m_difficulty.text = "NORMAL";
                    GameManager.Instance.AddGameSpeed(0.5f);
                    break;
                case DifficultyState.Hard:
                    m_difficulty.text = "HARD";
                    GameManager.Instance.AddGameSpeed(1f);
                    break;
                case DifficultyState.VeryHard:
                    m_difficulty.text = "VERYHARD";
                    GameManager.Instance.AddGameSpeed(1.5f);
                    break;
                case DifficultyState.Pirate:
                    m_difficulty.text = "PIRATES";
                    GameManager.Instance.AddGameSpeed(2f);
                    break;
            }
            m_currentState = difficultyState;
        }        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum DifficultyState
{
    None,
    Easy,
    Normal,
    Hard,
    VeryHard,
    Pirate
}

public class ProgressManager : MonoBehaviour
{
    [SerializeField] int m_easyToNormal = 50;
    [SerializeField] int m_normalToHard = 100;
    [SerializeField] int m_hardToVeryhard = 150;
    [SerializeField] int m_veryhardToPirates = 200;
    [SerializeField] Text m_difficulty = default;
    [SerializeField] Slider m_progressGauge = default;
    [SerializeField] Animator m_textAnim = default;
    DifficultyState difficultyState;
    DifficultyState m_currentState;
    float progressValue = 0;
    bool isMaxed = false;
    float r = 1.0f;
    float g = 0.0f;
    float b = 0.0f;

    public static DifficultyState finalStatus;

    private void Start()
    {
        m_textAnim.enabled = false;
        m_currentState = DifficultyState.None;
        difficultyState = DifficultyState.Easy;
    }

    void Update()
    {
        if (GameManager.Instance.GetInGame && !isMaxed)
        {
            progressValue += Time.deltaTime * GameManager.Instance.DashSpeed;
            //m_progressGauge.value = progressValue;

            if (progressValue >= 0 && progressValue < m_easyToNormal)
            {
                finalStatus = DifficultyState.Easy;
                difficultyState = DifficultyState.Easy;
            }
            else if (progressValue >= m_easyToNormal && progressValue < m_normalToHard)
            {
                difficultyState = DifficultyState.Normal;          
            }
            else if (progressValue >= m_normalToHard && progressValue < m_hardToVeryhard)
            {
                difficultyState = DifficultyState.Hard;
            }
            else if (progressValue >= m_hardToVeryhard && progressValue < m_veryhardToPirates)
            {
                difficultyState = DifficultyState.VeryHard;
            }
            else if (progressValue >= m_veryhardToPirates)
            {
                difficultyState = DifficultyState.Pirate;
                m_textAnim.enabled = true;
                isMaxed = true;
            }
        }
        else if (!GameManager.Instance.GetInGame)
        {
            finalStatus = difficultyState;
        }

        if (m_currentState != difficultyState)
        {
            Debug.Log(m_currentState);
            if (difficultyState != DifficultyState.None && difficultyState != DifficultyState.Easy) 
            { 
                AIwindowManager.Instance.ChangeAIByState(AIState.DifUpdate); 
            }

            switch (difficultyState)
            {
                case DifficultyState.Easy:
                    m_difficulty.text = "<color=#4FFFC5>EASY</color>";
                    break;
                case DifficultyState.Normal:
                    m_difficulty.text = "<color=#EDFF7C>NORMAL</color>";
                    GameManager.Instance.AddGameSpeed(0.5f);
                    EventManager.DifChangeEvent(1.1f);
                    break;
                case DifficultyState.Hard:
                    m_difficulty.text = "<color=#F1B343>HARD</color>";
                    GameManager.Instance.AddGameSpeed(1f);
                    EventManager.DifChangeEvent(1.2f);
                    break;
                case DifficultyState.VeryHard:
                    m_difficulty.text = "<color=#F15A44>VERYHARD</color>";
                    GameManager.Instance.AddGameSpeed(1.5f);
                    EventManager.DifChangeEvent(1.3f);
                    break;
                case DifficultyState.Pirate:
                    m_difficulty.text = "PIRATES";
                    GameManager.Instance.AddGameSpeed(2f);
                    EventManager.DifChangeEvent(1.5f);
                    break;
            }
            m_currentState = difficultyState;
        }        
    }
}

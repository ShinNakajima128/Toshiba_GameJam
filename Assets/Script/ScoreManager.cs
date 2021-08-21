using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text m_score;
    [SerializeField] Text m_difficulty;
    [SerializeField] Text m_resultScore;
    [SerializeField] Animator m_anim = default;
    int m_scoreCopy;
    string m_difficultyCopy;
    float m_result;
    public enum DifficultyRate
    {
        None,
        Easy,
        Normal,
        Hard,
        VeryHard,
        Pirate
    }
    void Start()
    {
        m_anim.enabled = false;
        m_score.text = GameManager.Instance.GetScore.ToString();
        m_difficultyCopy = ProgressManager.finalStatus.ToString();
        m_difficulty.text = DifColorChange(m_difficultyCopy);
        m_scoreCopy = GameManager.Instance.GetScore;
        m_result = Calculate(m_difficultyCopy);
        m_resultScore.text = m_result.ToString();
        
    }

    public float Calculate(string difficulty)
    {
        float result = default;
        float rate = default;
        switch (difficulty)
        {
            case "Easy":
                rate = 1;
                break;
            case "Normal":
                rate = 1.25f;
                break;
            case "Hard":
                rate = 1.5f;
                break;
            case "VeryHard":
                rate = 1.75f;
                break;
            case "Pirate":
                rate = 2;
                break;
            default:
                break;
        }
        result = m_scoreCopy * rate;

        return result;
    } 

    string DifColorChange(string dif)
    {
        string text = default;

        switch (dif)
        {
            case "Easy":
                text = "<color=#4FFFC5>EASY × 1</color>";
                //text = "EASY × 1";
                //m_anim.enabled = true;
                break;
            case "Normal":
                text = "<color=#EDFF7C>NORMAL × 1.25</color>";
                break;
            case "Hard":
                text = "<color=#F1B343>HARD × 1.5</color>";
                break;
            case "VeryHard":
                text = "<color=#F15A44>VERYHARD × 1.75</color>";
                break;
            case "Pairates":
                text = "PIRATES × 2";
                m_anim.enabled = true;
                break;
            default:
                break;
        }

        return text;
    }
}

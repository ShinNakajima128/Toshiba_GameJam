using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text m_score;
    [SerializeField] Text m_difficulty;
    [SerializeField] Text m_resultScore;
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
        m_score.text = GameManager.Instance.GetScore.ToString();
        m_difficultyCopy = ProgressManager.Instance.GetDifficulty.ToString();
        m_difficulty.text = m_difficultyCopy;
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


    // Update is called once per frame
    void Update()
    {
        
    }
}

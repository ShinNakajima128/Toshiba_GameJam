using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AIState
{
    Default,
    Damage,
    Eat,
    Smale,
    Sad,
    Angry,
    Impatience
}

public class AIwindowManager : MonoBehaviour
{
    [Header("AIのテキストリスト")]
    [SerializeField] string[] m_textList = default;
    [Header("AIのイメージリスト")]
    [SerializeField] Image[] m_imageList = default;
    [Header("ウィンドウに表示されるテキスト")]
    [SerializeField] Text m_aiText = default;
    [Header("ウィンドウに表示されるAIのイメージ")]
    [SerializeField] Image m_aiImage = default;
    Dictionary<AIState, Image> m_imageDic = new Dictionary<AIState, Image>();
    Dictionary<AIState, string> m_textDic = new Dictionary<AIState, string>();

    void Start()
    {
        for (int i = 0; i < m_imageList.Length; i++)
        {
            AIState State = (AIState)(i + 1);
            m_imageDic.Add(State, m_imageList[i]);
        }

        for (int i = 0; i < m_textList.Length; i++)
        {
            AIState State = (AIState)(i + 1);
            m_textDic.Add(State, m_textList[i]);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeAIByState(AIState.Damage);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeAIByState(AIState.Eat);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeAIByState(AIState.Smale);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeAIByState(AIState.Sad);
        }
    }

    public void ChangeAIByState(AIState state)
    {
        m_aiImage.sprite = m_imageDic[state].sprite;
        m_aiText.text = m_textDic[state];
    }
}

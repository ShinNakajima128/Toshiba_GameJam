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
    [SerializeField] Sprite[] m_spriteList = default;
    [Header("ウィンドウに表示されるテキスト")]
    [SerializeField] Text m_aiText = default;
    [Header("ウィンドウに表示されるAIのイメージ")]
    [SerializeField] Image m_aiImage = default;
    [Header("AIの状態がデフォルトに戻るまでの時間")]
    [SerializeField] float m_resetTime = 3.0f;
    Dictionary<AIState, Sprite> m_spriteDic = new Dictionary<AIState, Sprite>();
    Dictionary<AIState, string> m_textDic = new Dictionary<AIState, string>();

    Coroutine aiCoroutine = default;


    private void Awake()
    {
        for (int i = 0; i < m_spriteList.Length; i++)
        {
            AIState State = (AIState)(i);
            m_spriteDic.Add(State, m_spriteList[i]);
        }

        for (int i = 0; i < m_textList.Length; i++)
        {
            AIState State = (AIState)(i);
            m_textDic.Add(State, m_textList[i]);
        }
    }

    void Start()
    {
        ChangeAIByState(AIState.Default);
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
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ChangeAIByState(AIState.Angry);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            ChangeAIByState(AIState.Impatience);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            ChangeAIByState(AIState.Default);
        }
    }

    public void ChangeAIByState(AIState state)
    {
        if (aiCoroutine != null)
        {
            StopCoroutine(aiCoroutine);
            aiCoroutine = null;
            Debug.Log("コルーチンをリセット");
        }

        m_aiImage.sprite = m_spriteDic[state];
        m_aiText.text = m_textDic[state];

        PlayVoice(state);

        if (state != AIState.Default)
        {
            aiCoroutine = StartCoroutine(ResetAIState());
        }
    }

    void PlayVoice(AIState state)
    {
        SoundManager.Instance.StopVoice();

        switch(state)
        {
            case AIState.Default:
                break;
            case AIState.Damage:
                SoundManager.Instance.PlayVoiceByName("3-2");
                break;
            case AIState.Eat:
                SoundManager.Instance.PlayVoiceByName("3-1");
                break;
            case AIState.Smale:
                SoundManager.Instance.PlayVoiceByName("3-3");
                break;
            case AIState.Angry:
                SoundManager.Instance.PlayVoiceByName("2-1");
                break;
            case AIState.Sad:
                SoundManager.Instance.PlayVoiceByName("2-4");
                break;
            case AIState.Impatience:
                SoundManager.Instance.PlayVoiceByName("3-4");
                break;
        }
    }

    IEnumerator ResetAIState()
    {
        yield return new WaitForSeconds(m_resetTime);

        ChangeAIByState(AIState.Default);
    }
}

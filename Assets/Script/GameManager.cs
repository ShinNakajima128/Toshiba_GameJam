using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [Header("空腹ゲージの最大値")]
    [SerializeField] int m_maxStomachGauge = 100;
    [Header("空腹ゲージのイメージ")]
    [SerializeField] Image m_stomachImage = default;
    [Header("空腹ゲージのスライダー")]
    [SerializeField] Slider m_stomachSlider = default;
    [Header("空腹ゲージの減少速度")]
    [SerializeField] float m_decreaseSpeed = 1f;
    [SerializeField] float m_decreaseValue = 1f;
    float m_decreaseTimer = 0;
    [Header("レーザーゲージの最大値")]
    [SerializeField] int m_maxLaserGauge = 100;
    [Header("レーザーゲージのスライダー")]
    [SerializeField] Image m_laserImage = default;
    [Header("レーザーゲージのスライダー")]
    [SerializeField] Slider m_laserSlider = default;
    [Header("ゲームの状態")]
    [SerializeField] bool InGame = false;
    [Header("スコアを表示するテキスト")]
    [SerializeField] Text m_scoreText = default;
    [Header("ゲームスピード")]
    [SerializeField] float m_gameSpeed = 1.0f;
    float m_currentGameSpeed = 1f;
    [Header("ダッシュ時のスピード")]
    [SerializeField] float m_dashSpeed = 1.0f;
    [Header("ゲージの状況を知らせるアナウンスの間隔")]
    [SerializeField] float m_announceInterval = 10.0f;
    float m_currentDashSpeed = 1f;
    [Header("デバッグ用のリスタートボタン")]
    [SerializeField] GameObject m_restartButton = default;
    float m_currentStomachGauge = default;
    float m_currentLaserGauge = 0;
    static int m_score = default;
    [SerializeField] GameObject m_dashEffect;
    bool isGaugeMaxed = false;
    bool isStateChanged = false;
    float m_timer = 0;

    public int GetScore { get => m_score; }

    public float GameSpeed { get => m_currentGameSpeed; }

    public float DashSpeed { get => m_currentDashSpeed * GameSpeed; }

    public bool GetInGame { get => InGame; }

    public float LaserGauge 
    { 
        get => m_currentLaserGauge; 
        set 
        { 
            m_currentLaserGauge = value; 

            if (m_currentLaserGauge >= m_maxLaserGauge)
            {
                m_currentLaserGauge = m_maxLaserGauge;
            }
            EventManager.EPEvent(m_currentLaserGauge, m_maxLaserGauge);
        } 
    } 

    public bool GetIsGaugeMaxed { get => isGaugeMaxed; set { isGaugeMaxed = value; } }

    public int GetLaserMaxGauge { get => m_maxLaserGauge; }

    private void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        m_restartButton.SetActive(false);

        m_currentStomachGauge = m_maxStomachGauge;

        if (m_stomachImage) m_stomachImage.fillAmount = (float)m_currentStomachGauge / m_maxStomachGauge;
        if (m_stomachSlider && !m_stomachImage) { m_stomachSlider.maxValue = m_maxStomachGauge; }
        
        m_currentLaserGauge = 0;

        if (m_laserImage) m_laserImage.fillAmount = (float)m_currentLaserGauge / m_maxLaserGauge;
        if (m_laserSlider && !m_laserImage) m_laserSlider.maxValue = m_maxLaserGauge;

        if (SceneManager.GetActiveScene().name == "Title")
        {
            SoundManager.Instance.PlayVoiceByName("result");
        }
        else if (SceneManager.GetActiveScene().name == "Takeuchi")
        {
            Restart();
        }
        else if (SceneManager.GetActiveScene().name == "Ryu")
        {
            //SoundManager.Instance.StopVoice();
            AIwindowManager.Instance.ChangeAIByState(AIState.Result);
        }
    }

    /// <summary>
    /// 各Sceneへ遷移した時に処理を実行する
    /// </summary>
    /// <param name="nextScene"> 遷移後のScene </param>
    /// <param name="mode"></param>
    void OnSceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Ryu":
                SoundManager.Instance.StopVoice();
                AIwindowManager.Instance.ChangeAIByState(AIState.Result);
                break;
            case "Nakajima":
                SoundManager.Instance.StopSe();
                break;
            default:
                m_score = 0;
                break;
        }
    }
    private void Update()
    {
        if (InGame)
        {
            m_decreaseTimer += Time.deltaTime;
            if (m_decreaseTimer >= m_decreaseSpeed)
            {
                m_currentStomachGauge -= m_decreaseValue;
                EventManager.HPEvent(m_currentStomachGauge, m_maxStomachGauge);
                m_decreaseTimer = 0;
            }

            if (m_stomachImage) m_stomachImage.fillAmount = (float)m_currentStomachGauge / m_maxStomachGauge;
            if (m_stomachSlider && !m_stomachImage) m_stomachSlider.value = m_currentStomachGauge;

            if (m_laserImage) m_laserImage.fillAmount = (float)m_currentLaserGauge / m_maxLaserGauge;
            if (m_laserSlider && !m_laserImage) m_laserSlider.value = m_currentLaserGauge;

            if (m_currentLaserGauge >= m_maxLaserGauge && !isGaugeMaxed)
            {
                Debug.Log("レーザー発射可能");
                AIwindowManager.Instance.ChangeAIByState(AIState.GaugeMax);
                SoundManager.Instance.PlaySeByName("4_charge");
                isGaugeMaxed = true;
                m_currentLaserGauge = m_maxLaserGauge;
                EventManager.EPEvent(m_currentLaserGauge, m_maxLaserGauge);
            }

            if (m_currentStomachGauge <= m_maxStomachGauge * 0.5 && !isStateChanged)
            {
                isStateChanged = true;
                AIwindowManager.Instance.ChangeAIByState(AIState.Diminish);
                StartCoroutine(WaitFlagReturn());
            }

            if (m_currentStomachGauge <= 0)
            {
                InGame = false;
                Debug.Log("ゲーム終了");
                StartCoroutine(LoadResult());
                AIwindowManager.Instance.ChangeAIByState(AIState.Gameover);
                if (m_dashEffect)
                    m_dashEffect.SetActive(false);
                EventManager.GameEnd();
                return;
            }
            if (Input.GetButton("Dash"))
            {
                m_currentDashSpeed = m_dashSpeed;
                if (m_dashEffect)
                    m_dashEffect.SetActive(true);
            }
            else
            {
                if (m_dashEffect)
                    m_dashEffect.SetActive(false);
                m_currentDashSpeed = 1f;
            }
        }
    }
    public void GameStart()
    {
        EventManager.GameStart();
        m_restartButton.SetActive(false);
        m_currentGameSpeed = m_gameSpeed;
        m_currentDashSpeed = 1f;
        m_score = 0;
        m_scoreText.text = "スコア : " + m_score.ToString();
        if (m_dashEffect)
            m_dashEffect.SetActive(false);
    }
    /// <summary>
    /// ゲームをリスタートする。デバッグボタン用
    /// </summary>
    public void Restart()
    {
        InGame = true;
        m_currentStomachGauge = m_maxStomachGauge;
        EventManager.GameStart();
        //m_restartButton.SetActive(false);
    }

    /// <summary>
    /// スコアを加算する
    /// </summary>
    /// <param name="value"> 加算する量 </param>
    public void AddScore(int value)
    {
        SoundManager.Instance.PlaySeByName("8_get_tresure");
        m_score += value;
        m_scoreText.text = "スコア : " + m_score.ToString();
        EventManager.GetScore(value);
    }

    /// <summary>
    /// 空腹ゲージを回復させる
    /// </summary>
    /// <param name="value"> 回復量 </param>
    public void Recovery(int value)
    {
        SoundManager.Instance.PlaySeByName("3_eat");

        if (!LaserManager.isShooted)
        {
            m_currentLaserGauge += value / 3;
            EventManager.EPEvent(m_currentLaserGauge, m_maxLaserGauge);
        }

        m_currentStomachGauge += value;

        if (m_currentStomachGauge >= m_maxStomachGauge)
        {
            m_currentStomachGauge = m_maxStomachGauge;
        }
        EventManager.HPEvent(m_currentStomachGauge, m_maxStomachGauge);
    }

    /// <summary>
    /// ダメージを受ける
    /// </summary>
    /// <param name="value"> ダメージ量 </param>
    public void Damage(int value)
    {
        m_currentStomachGauge -= value;
        EventManager.HPEvent(m_currentStomachGauge, m_maxStomachGauge);
    }

    public void AddGameSpeed(float value)
    {
        m_currentGameSpeed += value;
    }

    public void DebugGaugeMax()
    {
        Debug.Log("debug");
        m_currentLaserGauge += m_maxLaserGauge + 10;
    }

    IEnumerator WaitFlagReturn()
    {
        yield return new WaitForSeconds(m_announceInterval);

        isStateChanged = false;
    }

    IEnumerator LoadResult()
    {
        yield return new WaitForSeconds(2.0f);

        LoadSceneManager.Instance.LoadResultScene();
    }
}

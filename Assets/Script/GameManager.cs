using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [Header("空腹ゲージの最大値")]
    [SerializeField] int m_stomachGauge = 100;
    [Header("空腹ゲージのスライダー")]
    [SerializeField] Slider m_stomachSlider = default;
    [Header("空腹ゲージの減少速度")]
    [SerializeField] float m_decreaseSpeed = 0.01f;
    [Header("ゲームの状態")]
    [SerializeField] bool InGame = false;
    [Header("スコアを表示するテキスト")]
    [SerializeField] Text m_scoreText = default;
    [Header("ゲームスピード")]
    [SerializeField] float m_gameSpeed = 1.0f;
    float m_currentGameSpeed = 1f;
    [Header("ダッシュ時のスピード")]
    [SerializeField] float m_dashSpeed = 1.0f;
    float m_currentDashSpeed = 1f;
    [Header("デバッグ用のリスタートボタン")]
    [SerializeField] GameObject m_restartButton = default;
    float stomachGauge = default;
    int m_score = default;
    [SerializeField] GameObject m_dashEffect;

    public int GetScore { get => m_score; }

    public float GameSpeed { get => m_currentGameSpeed; }

    public float DashSpeed { get => m_currentDashSpeed * GameSpeed; }

    public bool GetInGame { get => InGame; }

    private void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        m_restartButton.SetActive(false);
        stomachGauge = m_stomachGauge;
        InGame = true;

        if (SceneManager.GetActiveScene().name == "Title")
        {

        }
        else if (SceneManager.GetActiveScene().name == "GameSCene")
        {

        }
        else if (SceneManager.GetActiveScene().name == "Result")
        {

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
            case "GameScene":
                m_score = 0;
                break;
        }
    }
    private void Update()
    {
        if (InGame)
        {
            stomachGauge -= Time.deltaTime * m_decreaseSpeed;
            if (m_stomachSlider) m_stomachSlider.value = stomachGauge;
            if (stomachGauge <= 0)
            {
                InGame = false;
                m_restartButton.SetActive(true);
                EventManager.GameEnd(); 
                if (m_dashEffect)
                    m_dashEffect.SetActive(false);
                Debug.Log("ゲーム終了");
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
        stomachGauge = m_stomachGauge;
        EventManager.GameStart();
        m_restartButton.SetActive(false);
    }

    /// <summary>
    /// スコアを加算する
    /// </summary>
    /// <param name="value"> 加算する量 </param>
    public void AddScore(int value)
    {
        m_score += value;
        m_scoreText.text = "スコア : " + m_score.ToString();
    }

    /// <summary>
    /// 空腹ゲージを回復させる
    /// </summary>
    /// <param name="value"> 回復量 </param>
    public void Recovery(int value)
    {
        stomachGauge += value;

        if (stomachGauge >= 100)
        {
            stomachGauge = 100;
        }
    }

    /// <summary>
    /// ダメージを受ける
    /// </summary>
    /// <param name="value"> ダメージ量 </param>
    public void Damage(int value)
    {
        stomachGauge -= value;
    }
}

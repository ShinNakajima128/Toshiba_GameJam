using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField] float m_stomachGauge = 100;
    [SerializeField] bool InGame = false;
    [SerializeField] Slider m_stomachSlider = default;
    int m_score = default;
    

    public int GetScore { get => m_score; }

    private void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
       if (InGame)
        {
            m_stomachGauge -= Time.deltaTime;
            if (m_stomachSlider) m_stomachSlider.value = m_stomachGauge;
            if (m_stomachGauge <= 0) { InGame = false; Debug.Log("ゲーム終了"); }
        }
    }

    /// <summary>
    /// スコアを加算する
    /// </summary>
    /// <param name="value"> 加算する量 </param>
    public void AddScore(int value)
    {
        m_score += value;
    }

    /// <summary>
    /// 空腹ゲージを回復させる
    /// </summary>
    /// <param name="value"> 回復量 </param>
    public void Recovery(int value)
    {
        m_stomachGauge += value;

        if (m_stomachGauge >= 100)
        {
            m_stomachGauge = 100;
        }
    }

    /// <summary>
    /// ダメージを受ける
    /// </summary>
    /// <param name="value"> ダメージ量 </param>
    public void Damage(int value)
    {
        m_stomachGauge -= value;
    }
}

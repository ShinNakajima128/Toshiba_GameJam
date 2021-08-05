using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TitleState
{
    Start,
    Main,
    Audio,
    Help,
}

public class TitleManager : MonoBehaviour
{
    [Header("スタート画面")]
    [SerializeField] GameObject m_start = default;
    [Header("メイン選択画面")]
    [SerializeField] GameObject m_main = default;
    [Header("オーディオ画面")]
    [SerializeField] GameObject m_audio = default;
    [Header("ヘルプ画面")]
    [SerializeField] GameObject m_help = default;
    [Header("ヘルプ画面時のゲーム説明用の画像")]
    [SerializeField] Image[] m_helpImages = default;
    TitleState m_titleState = TitleState.Start;

    void Start()
    {
        SoundManager.Instance.PlayVoiceByName("Ex_1_1");
        m_start.SetActive(true);
        m_main.SetActive(false);
        m_audio.SetActive(false);
        m_help.SetActive(false);
    }

    void Update()
    {
        if (m_titleState == TitleState.Start && Input.anyKeyDown)
        {
            MainActive();
        }

        if (m_titleState == TitleState.Main && Input.GetKeyDown(KeyCode.Escape))
        {
            StartActive();
        }
    }

    public void StartActive()
    {
        SoundManager.Instance.PlaySeByName("5_2_cancel");
        m_titleState = TitleState.Start;
        if (m_main.activeSelf) m_main.SetActive(false);
        
        m_start.SetActive(true);
    }

    /// <summary>
    /// メイン画面を表示する
    /// </summary>
    public void MainActive()
    {
        SoundManager.Instance.PlaySeByName("5_1_select");
        m_titleState = TitleState.Main;
        if (m_start.activeSelf) m_start.SetActive(false);
        if (m_audio.activeSelf) m_audio.SetActive(false);
        if (m_help.activeSelf) m_help.SetActive(false);

        m_main.SetActive(true);
    }
    /// <summary>
    /// オーディオ画面を表示する
    /// </summary>
    public void AudioActive()
    {
        SoundManager.Instance.PlaySeByName("5_1_select");
        m_titleState = TitleState.Audio;
        if (m_main.activeSelf) m_main.SetActive(false);
        m_audio.SetActive(true);
    }
    /// <summary>
    /// ヘルプ画面を表示する
    /// </summary>
    public void HelpActive()
    {
        SoundManager.Instance.PlaySeByName("5_1_select");
        m_titleState = TitleState.Help;
        if (m_main.activeSelf) m_main.SetActive(false);
        m_help.SetActive(true);
    }
}

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
    [Header("タイトルロゴ")]
    [SerializeField] GameObject m_titleLogo = default;
    [Header("スタート画面")]
    [SerializeField] GameObject m_start = default;
    [Header("メイン選択画面")]
    [SerializeField] GameObject m_main = default;
    [Header("オーディオ画面")]
    [SerializeField] GameObject m_audio = default;
    [Header("ヘルプ画面")]
    [SerializeField] GameObject m_help = default;
    
    Slider m_masterSlider;
    Slider m_bgmSlider;
    Slider m_seSlider;
    Slider m_voiceSlider;
    TitleState m_titleState = TitleState.Start;
    int titleType = 0;

    private void Awake()
    {
        AudioActive();
    }

    void Start()
    {
        
        SoundManager.Instance.PlayVoiceByName("title_fix");
        m_masterSlider = GameObject.FindGameObjectWithTag("MASTER").GetComponent<Slider>();
        m_bgmSlider = GameObject.FindGameObjectWithTag("BGM").GetComponent<Slider>();
        m_seSlider = GameObject.FindGameObjectWithTag("SE").GetComponent<Slider>();
        m_voiceSlider = GameObject.FindGameObjectWithTag("VOICE").GetComponent<Slider>();

        if (m_masterSlider)
        {
            m_masterSlider.value = SoundManager.Instance.GetMasterVolume;
            Debug.Log("マスター音量：" + m_masterSlider.value);
        }
        if (m_bgmSlider)
        {
            m_bgmSlider.value = SoundManager.Instance.GetBgmVolume;
            Debug.Log("BGM音量：" + m_bgmSlider.value);
        }
        if (m_seSlider)
        {
            m_seSlider.value = SoundManager.Instance.GetSeVolume;
            Debug.Log("SE音量：" + m_seSlider.value);
        }
        if (m_voiceSlider)
        {
            m_voiceSlider.value = SoundManager.Instance.GetVoiceVolume;
            Debug.Log("ボイス音量：" + m_voiceSlider.value);
        }

        StartActive();
        titleType = 0;
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
            titleType = 0;
        }
    }

    public void StartActive()
    {
        if (titleType == 1)
        {
            SoundManager.Instance.PlaySeByName("5_2_cancel");
            titleType = 0;
        }
        m_titleState = TitleState.Start;
        if (m_main.activeSelf) m_main.SetActive(false);
        if (m_audio.activeSelf) m_audio.SetActive(false);

        m_start.SetActive(true);
    }

    /// <summary>
    /// メイン画面を表示する
    /// </summary>
    public void MainActive()
    {
        Debug.Log(titleType);
        if (titleType == 0) SoundManager.Instance.PlaySeByName("5_1_select");
        if (titleType == 2) SoundManager.Instance.PlaySeByName("5_2_cancel");
        m_titleState = TitleState.Main;
        if (m_start.activeSelf) m_start.SetActive(false);
        if (m_audio.activeSelf) m_audio.SetActive(false);
        if (m_help.activeSelf) m_help.SetActive(false);
        if (m_titleLogo) m_titleLogo.SetActive(true);

        m_main.SetActive(true);
        titleType = 1;
    }
    /// <summary>
    /// オーディオ画面を表示する
    /// </summary>
    public void AudioActive()
    {
        if (titleType == 1) SoundManager.Instance.PlaySeByName("5_1_select");
        m_titleState = TitleState.Audio;
        if (m_main.activeSelf) m_main.SetActive(false);
        m_audio.SetActive(true);
        titleType = 2;
    }
    /// <summary>
    /// ヘルプ画面を表示する
    /// </summary>
    public void HelpActive()
    {
        if (titleType == 1) SoundManager.Instance.PlaySeByName("5_1_select");
        m_titleState = TitleState.Help;
        if (m_main.activeSelf) m_main.SetActive(false);
        if (m_titleLogo) m_titleLogo.SetActive(false);
        m_help.SetActive(true);
        titleType = 2;
    }

    /// <summary>
    /// マスター音量を設定する
    /// </summary>
    public void SetMasterVolume()
    {
        SoundManager.Instance.MasterVolChange(m_masterSlider.value);
    }
    /// <summary>
    /// BGM音量を設定する
    /// </summary>
    public void SetBgmVolume()
    {
        SoundManager.Instance.BgmVolChange(m_bgmSlider.value);
    }
    /// <summary>
    /// SE音量を設定する
    /// </summary>
    public void SetSeVolume()
    {
        SoundManager.Instance.SeVolChange(m_seSlider.value);
    }
    /// <summary>
    /// ボイス音量を設定する
    /// </summary>
    public void SetVoiceVolume()
    {
        SoundManager.Instance.VoiceVolChange(m_voiceSlider.value);
    }

    public void QuitGameButton()
    {
        LoadSceneManager.Instance.QuitGame();
    }
}

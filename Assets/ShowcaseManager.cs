using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowcaseManager : MonoBehaviour
{
    [SerializeField] GameObject m_panel = default;

    public void ActiveSwitch()
    {
        if (m_panel.activeSelf)
        {
            m_panel.SetActive(false);
        }
        else if (!m_panel.activeSelf)
        {
            m_panel.SetActive(true);
        }

        SoundManager.Instance.PlaySeByName("5_1_select");
    }

    public void LoadTitle()
    {
        LoadSceneManager.Instance.LoadTitleScene();

        SoundManager.Instance.PlaySeByName("9_warp");
    }

    public void PlayVoice1()
    {
        SoundManager.Instance.StopVoice();
        SoundManager.Instance.PlayVoiceByName("title_fix");
    }

    public void PlayVoice2()
    {
        SoundManager.Instance.StopVoice();
        SoundManager.Instance.PlayVoiceByName("1-2");
    }

    public void PlayVoice3()
    {
        SoundManager.Instance.StopVoice();
        SoundManager.Instance.PlayVoiceByName("2-2");
    }

    public void PlayVoice4()
    {
        SoundManager.Instance.StopVoice();
        SoundManager.Instance.PlayVoiceByName("2-3");
    }

    public void PlayVoice5()
    {
        SoundManager.Instance.StopVoice();
        SoundManager.Instance.PlayVoiceByName("3-2");
    }

    public void PlayVoice6()
    {
        SoundManager.Instance.StopVoice();
        SoundManager.Instance.PlayVoiceByName("3-4");
    }

    public void PlayVoice7()
    {
        SoundManager.Instance.StopVoice();
        SoundManager.Instance.PlayVoiceByName("3-1");
    }

    public void PlayVoice8()
    {
        SoundManager.Instance.StopVoice();
        SoundManager.Instance.PlayVoiceByName("2-4");
    }

    public void PlayVoice9()
    {
        SoundManager.Instance.StopVoice();
        SoundManager.Instance.PlayVoiceByName("result");
    }
}

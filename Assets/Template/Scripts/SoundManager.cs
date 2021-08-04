using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class SoundManager : SingletonMonoBehaviour<SoundManager>
{
    public  float m_masterVolume = 1.0f;
    public  float m_bgmVolume = 0.1f;
    public  float m_seVolume = 1.0f;
    public  float m_voiceVolume = 1.0f;
    [Header("BGMのリスト")]
    [SerializeField] AudioClip[] m_bgms = null;
    [Header("SEのリスト")]
    [SerializeField] AudioClip[] m_ses = null;
    [Header("Voiceのリスト")]
    [SerializeField] AudioClip[] m_voices = null;
    [Header("BGMのAudioSource")]
    [SerializeField] AudioSource m_bgmAudioSource = null;
    [Header("SEのAudioSource")]
    [SerializeField] AudioSource m_seAudioSource = null;
    [Header("VOICEのAudioSource")]
    [SerializeField] AudioSource m_voiceAudioSource = null;
    [Header("MasterのAudioMixer")]
    [SerializeField] AudioMixerGroup m_masterMixer = default;
    [Header("BGMのAudioMixer")]
    [SerializeField] AudioMixerGroup m_bgmMixer = default;
    [Header("SEのAudioMixer")]
    [SerializeField] AudioMixerGroup m_seMixer = default;
    [Header("VOICEのAudioMixer")]
    [SerializeField] AudioMixerGroup m_voiceMixer = default;
    Dictionary<string, int> bgmIndex = new Dictionary<string, int>();
    Dictionary<string, int> seIndex = new Dictionary<string, int>();
    Dictionary<string, int> voiceIndex = new Dictionary<string, int>();
    public static bool isLosted = false;


    void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        for (int i = 0; i < m_bgms.Length; i++)
        {
            bgmIndex.Add(m_bgms[i].name, i);
        }

        for (int i = 0; i < m_ses.Length; i++)
        {
            seIndex.Add(m_ses[i].name, i);
        }

        for (int i = 0; i < m_voices.Length; i++)
        {
            voiceIndex.Add(m_voices[i].name, i);
        }
    }

    private void Start()
    {
        if (Instance != null)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            if (SceneManager.GetActiveScene().name == "Title")
            {
                PlayBgmByName("Title");
            }
            else if (SceneManager.GetActiveScene().name == "")
            {
                PlayBgmByName("");
            }
            else if (SceneManager.GetActiveScene().name == "")
            {
                PlayBgmByName("");
            }
            else if (SceneManager.GetActiveScene().name == "")
            {
                PlayBgmByName("");
            }
            else if (SceneManager.GetActiveScene().name == "")
            {
                PlayBgmByName("");
            }
        }  
    }

    /// <summary>
    /// Sceneが遷移した時にBGMを変更する
    /// </summary>
    /// <param name="nextScene">遷移後のScene</param>
    /// <param name="mode"></param>
    void OnSceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        if (Instance != null)
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "Title":
                    PlayBgmByName("Title");
                    break;
                //case "":
                //    PlayBgmByName("");
                //    break;
                //case "":
                //    PlayBgmByName("");
                //    break;
                //case "":
                //    PlayBgmByName("");
                //    break;
                //case "":
                //    PlayBgmByName("");
                //    break;
            }
        } 
    }

    void Update()
    {
        m_bgmAudioSource.volume = m_bgmVolume * m_masterVolume;
        m_seAudioSource.volume = m_seVolume * m_masterVolume;
        m_voiceAudioSource.volume = m_voiceVolume * m_masterVolume;
    }

    int GetBgmIndex(string name)
    {
        if (bgmIndex.ContainsKey(name))
        {
            return bgmIndex[name];
        }
        else
        {
            return 0;
        }
    }

    int GetSeIndex(string name)
    {
        if (seIndex.ContainsKey(name))
        {
            return seIndex[name];
        }
        else
        {
            return 0;
        }
    }

    public int GetVoiceIndex(string name)
    {
        if (voiceIndex.ContainsKey(name))
        {
            return voiceIndex[name];
        }
        else
        {
            return 0;
        }
    }
    void PlayBgm(int index)
    {
        if (Instance != null)
        {
            index = Mathf.Clamp(index, 0, m_bgms.Length);

            m_bgmAudioSource.clip = m_bgms[index];
            m_bgmAudioSource.loop = true;
            m_bgmAudioSource.volume = m_bgmVolume * m_masterVolume;
            m_bgmAudioSource.Play();
        }
    }

    /// <summary>
    /// BGMを再生する
    /// </summary>
    /// <param name="name"> BGMの名前 </param>
    public void PlayBgmByName(string name)
    {
        PlayBgm(GetBgmIndex(name));
    }

    /// <summary>
    /// BGMを止める
    /// </summary>
    public void StopBgm()
    {
        m_bgmAudioSource.Stop();
        m_bgmAudioSource.clip = null;
    }

    void PlaySe(int index)
    {
        index = Mathf.Clamp(index, 0, m_ses.Length);

        m_seAudioSource.PlayOneShot(m_ses[index], m_seVolume * m_masterVolume);
    }

    /// <summary>
    /// SEを再生する
    /// </summary>
    /// <param name="name"> SEの名前 </param>
    public void PlaySeByName(string name)
    {
        PlaySe(GetSeIndex(name));
    }

    /// <summary>
    /// SEを止める
    /// </summary>
    public void StopSe()
    {
        m_seAudioSource.Stop();
        m_seAudioSource.clip = null;
    }

    void PlayVoice(int index)
    {
        index = Mathf.Clamp(index, 0, m_voices.Length);

        m_voiceAudioSource.PlayOneShot(m_voices[index], m_voiceVolume * m_masterVolume);
    }

    /// <summary>
    /// Voiceを再生する
    /// </summary>
    /// <param name="name"> BGMの名前 </param>
    public void PlayVoiceByName(string name)
    {
        PlayVoice(GetVoiceIndex(name));
    }

    /// <summary>
    /// Voiceを止める
    /// </summary>
    public void StopVoice()
    {
        m_voiceAudioSource.Stop();
        m_voiceAudioSource.clip = null;
    }

    public void MasterVolChange()
    {
        m_masterVolume = GameObject.FindGameObjectWithTag("Master").GetComponent<Slider>().value;
        Debug.Log(m_masterVolume);
    }
    public void BGMVolChange()
    {
        m_bgmVolume = GameObject.FindGameObjectWithTag("BGM").GetComponent<Slider>().value;
        Debug.Log(m_bgmVolume);
    }
    public void SEVolChange()
    {
        m_seVolume = GameObject.FindGameObjectWithTag("SE").GetComponent<Slider>().value;
        Debug.Log(m_seVolume);
    }
    public void VoiceVolChange()
    {
        m_voiceVolume = GameObject.FindGameObjectWithTag("Voice").GetComponent<Slider>().value;
        Debug.Log(m_voiceVolume);
    }
}
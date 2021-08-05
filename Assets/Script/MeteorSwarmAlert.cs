using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteorSwarmAlert : MonoBehaviour
{
    [Header("警告用のテキスト")]
    [SerializeField] Text m_alert = default;
    [Header("右側の流星群警告アイコン")]
    [SerializeField] GameObject m_rightAlertImage = default;
    [Header("左側の流星群警告アイコン")]
    [SerializeField] GameObject m_leftAlertImage = default;

    [SerializeField] SpawnMachine m_spawn;
    [SerializeField] Transform[] m_starPoint;
    [SerializeField] float m_starTimer = 10f;
    float m_timer = 0;
    bool m_playGame;
    private void Start()
    {
        GameStart();
        m_alert.text = "";
        m_rightAlertImage.SetActive(false);
        m_leftAlertImage.SetActive(false);
        EventManager.OnGameEnd += GameEnd;
    }

    void Update()
    {
        if (!m_playGame)
        {
            return;
        }
        if (m_timer <= m_starTimer)
        {
            m_timer += GameManager.Instance.GameSpeed * Time.deltaTime;
            if (m_timer >= m_starTimer)
            {
                StartMeteorSwarmAlert();
            }
        }
    }

    /// <summary>
    /// 流星群の警告開始
    /// </summary>
    public void StartMeteorSwarmAlert()
    {
        int type = Random.Range(0, 2);
        if (type == 0)
        {
            StartCoroutine(CountDown(m_leftAlertImage, type));
        }
        else
        {
            StartCoroutine(CountDown(m_rightAlertImage, type));
        }
    }

    IEnumerator CountDown(GameObject alertIcon, int type)
    {
        m_alert.text = "流星群が近づいている！";
        alertIcon.SetActive(true);
        SoundManager.Instance.PlaySeByName("6_1_alart");
        EffectManager.Instance.PlayShake(8f);
        yield return new WaitForSeconds(2.0f);
        if (m_playGame)
            m_alert.text = "3";
        yield return new WaitForSeconds(1.0f);
        if (m_playGame)
            m_alert.text = "2";
        yield return new WaitForSeconds(1.0f);
        if (m_playGame)
            m_alert.text = "1";
        yield return new WaitForSeconds(1.0f);
        if (m_playGame)
            alertIcon.SetActive(false);
        m_alert.text = "";
        //Debug.Log("流星群飛来");
        if (m_playGame)
            m_spawn.Spawn(m_starPoint[type].position);
        m_timer = 0;
    }
    void GameStart()
    {
        m_playGame = true;
        m_timer = 0;
    }
    void GameEnd()
    {
        m_playGame = false;
    }
}

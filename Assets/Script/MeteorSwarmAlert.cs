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
    [Header("デバッグ用のフラグ")]
    [SerializeField] bool m_debugWarning = false;
    public static bool isStartWarning = false;

    private void Start()
    {
        m_alert.text = "";
        m_rightAlertImage.SetActive(false);
        m_leftAlertImage.SetActive(false);
    }

    void Update()
    {
        if (isStartWarning || m_debugWarning)
        {
            StartMeteorSwarmAlert();
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
            StartCoroutine(CountDown(m_leftAlertImage));
        }
        else
        {
            StartCoroutine(CountDown(m_rightAlertImage));
        }

        isStartWarning = false;
        m_debugWarning = false;
    }

    IEnumerator CountDown(GameObject alertIcon)
    {
        m_alert.text = "流星群が近づいている！";
        alertIcon.SetActive(true);

        yield return new WaitForSeconds(2.0f);
        m_alert.text = "3";

        yield return new WaitForSeconds(1.0f);
        m_alert.text = "2";

        yield return new WaitForSeconds(1.0f);
        m_alert.text = "1";

        yield return new WaitForSeconds(1.0f);
        alertIcon.SetActive(false);
        m_alert.text = "";
        Debug.Log("流星群飛来");
    }
}

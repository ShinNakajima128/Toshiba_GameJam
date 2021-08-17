using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EPManager : MonoBehaviour
{
    [SerializeField] Image m_epGauge = default;
    [SerializeField] float m_speed = 5f;
    Color m_color;
    bool m_full = false;
    private void Start()
    {
        m_color = m_epGauge.color;
    }
    private void OnEnable()
    {
        EventManager.OnEPEvent += ViewGauge;
    }
    private void OnDisable()
    {
        EventManager.OnEPEvent -= ViewGauge;
    }
    void ViewGauge(float current, float max)
    {
        if (current / max >= 1)
        {
            if (!m_full)
            {
                m_full = true;
                StartCoroutine(FullGauge());
            }
        }
        else if(current / max <= 0.2f && m_full)
        {
            m_full = false;
        }
        m_epGauge.fillAmount = current / max;
    }
    IEnumerator FullGauge()
    {
        Debug.Log("!");
        bool up = true;
        float b = 0;
        while (m_full)
        {
            if (up)
            {
                b += m_speed * Time.deltaTime;
                if (b >= 1)
                {
                    b = 1;
                    up = false;
                }
            }
            else
            {
                b -= m_speed * Time.deltaTime;
                if (b <= 0)
                {
                    b = 0;
                    up = true;
                }
            }
            m_epGauge.color = new Color(1, 1, b);
            yield return new WaitForEndOfFrame();
        }
        m_epGauge.color = m_color;
    }
}

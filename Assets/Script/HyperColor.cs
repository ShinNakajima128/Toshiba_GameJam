using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperColor : MonoBehaviour
{
    [SerializeField] Renderer m_renderer;
    [SerializeField] float m_speed = 5f;
    [SerializeField] float m_maxA = 0.9f;
    [SerializeField] float m_minA = 0.5f;
    bool m_up = true;
    float m_a = 0;
    private void Update()
    {
        if (m_up)
        {
            m_a += m_speed * Time.deltaTime;
            if (m_a >= m_maxA)
            {
                m_a = m_maxA;
                m_up = false;
            }
        }
        else
        {
            m_a -= m_speed * Time.deltaTime;
            if (m_a <= m_minA)
            {
                m_a = m_minA;
                m_up = true;
            }
        }
        m_renderer.material.color = new Color(1, 1, 1, m_a);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// スコアを表示する
/// </summary>
public class ViewText : MonoBehaviour
{
    [SerializeField] Text m_text;
    [SerializeField] float m_lifeTime = 1f;
    float m_timer = 0;
    private void Start()
    {
        m_timer = m_lifeTime;
    }
    void Update()
    {
        m_timer -= Time.deltaTime;
        if (m_timer <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void SetText(int text)
    {
        if (text == 0)
        {
            m_timer = 0;
            return;
        }
        m_text.text = text.ToString();
    }
    public void SetText(int text,Color color)
    {
        if (text == 0)
        {
            m_timer = 0;
            return;
        }
        m_text.text = text.ToString();
        m_text.color = color;
    }
}

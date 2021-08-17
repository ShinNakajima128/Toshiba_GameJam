using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    [SerializeField] Text m_calc = default;
    [SerializeField] Text m_resultText = default;
    [SerializeField] GameObject m_selectPanel = default;
    [SerializeField] float m_timer = 1;
    // Start is called before the first frame update
    void Start()
    {
        m_calc.enabled = false;
        m_resultText.enabled = false;
        m_selectPanel.SetActive(false);

        StartCoroutine(OnResult());
    }
    
    IEnumerator OnResult()
    {
        yield return new WaitForSeconds(m_timer);
        m_calc.enabled = true;
        yield return new WaitForSeconds(m_timer);
        m_resultText.enabled = true;
        yield return new WaitForSeconds(m_timer);
        m_selectPanel.SetActive(true);
    }
}

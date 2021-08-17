using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EPManager : MonoBehaviour
{
    [SerializeField] Image m_epGauge = default;

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
        m_epGauge.fillAmount = current / max;
    }
}

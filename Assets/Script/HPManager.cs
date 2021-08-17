using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    [SerializeField] Image m_hpGauge = default;

    private void OnEnable()
    {
        EventManager.OnHPEvent += ViewGauge;
    }
    private void OnDisable()
    {
        EventManager.OnHPEvent -= ViewGauge;
    }
    void ViewGauge(float current, float max)
    {
        m_hpGauge.fillAmount = current / max;
    }
}

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
    }

    public void LoadTitle()
    {
        LoadSceneManager.Instance.LoadTitleScene();
    }
}

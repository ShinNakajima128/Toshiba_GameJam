using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotControl : MonoBehaviour
{
    [SerializeField] Transform m_muzzle;
    [SerializeField] GameObject m_shotPrefab;
    [SerializeField] float m_shotInterval = 0.3f;
    float m_shotTimer = 0;
    bool m_shot = false;
    private void Start()
    {
        m_shot = true;
        EventManager.OnGameEnd += GameEnd;
    }
    void Update()
    {
        if (!m_shot)
        {
            return;
        }
        if (m_shotTimer <= 0)
        {
            //if (Input.GetButton("Fire1")||Input.GetButton("Jump"))
            {
                SoundManager.Instance.PlaySeByName("1_shot_fix");
                Instantiate(m_shotPrefab).transform.position = m_muzzle.position;
                m_shotTimer = m_shotInterval;
            }
        }
        else
        {
            m_shotTimer -= Time.deltaTime;
        }
    }
    void GameStart()
    {
        m_shot = true;
        m_shotTimer = 0;
    }
    void GameEnd()
    {
        m_shot = false;
    }
}

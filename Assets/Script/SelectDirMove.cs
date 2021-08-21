using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 指定方向へ直進のみ行う
/// </summary>
public class SelectDirMove : MoveControl
{
    Rigidbody m_rB;
    [SerializeField] float m_moveSpeed = 2f;
    [SerializeField] Vector3 m_dir = Vector3.back;
    [SerializeField] bool m_noDash = false;
    bool m_moveF; 
    void Start()
    {
        m_moveF = true;
        m_rB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!m_moveF && !m_noDash) return;
        if (m_noDash)
        {
            m_rB.velocity = m_dir * m_moveSpeed * GameManager.Instance.GameSpeed;
        }
        else
        {
            m_rB.velocity = m_dir * m_moveSpeed * GameManager.Instance.DashSpeed;
        }
    }
    public override void GameEnd()
    {
        m_moveF = false;
        m_rB.velocity = Vector3.zero;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveControl : MoveControl
{
    Rigidbody m_rB;
    [SerializeField] float m_moveSpeed = 2f;
    bool m_moveF;
    void Start()
    {
        m_moveF = true;
        m_rB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!m_moveF) 
        {
            m_rB.velocity = Vector3.zero;
            return;
        }
        float x = Input.GetAxisRaw("Horizontal");
        //float y = Input.GetAxisRaw("Vertical");
        m_rB.velocity = new Vector3(x * m_moveSpeed, 0, 0);
    }
    public override void GameEnd()
    {
        m_moveF = false;
    }
}

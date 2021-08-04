using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStarFall : MonoBehaviour
{
    [SerializeField] SpawnMachine m_spawn;
    [SerializeField] Transform[] m_starPoint;
    [SerializeField] float m_starTimer = 5f;
    float m_timer = 0;
    void Update()
    {
        m_timer += Time.deltaTime;
        if(m_timer >= m_starTimer)
        {
            int r = Random.Range(0, m_starPoint.Length);
            m_spawn.Spawn(m_starPoint[r].position);
            m_timer = 0;
        }
    }
}

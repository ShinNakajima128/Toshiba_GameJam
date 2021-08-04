using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 自動生成のコントローラー
/// </summary>
public class SpawnControl : MonoBehaviour
{
    [SerializeField] float[] m_spawnSpeed;
    [SerializeField] float[] m_spawnTime;
    [SerializeField] SpawnMachine[] m_spawnObjects;
    [SerializeField] Transform[] m_spwanPos;
    float[] m_allSpawnSpeed;
    float[] m_timers;
    bool m_spawn = false;
    int m_count = 0;
    void Start()
    {
        StartSpawn();
        EventManager.OnGameEnd += StopSpawn;
        m_timers = new float[m_spawnSpeed.Length];
        m_allSpawnSpeed = new float[m_spawnSpeed.Length];
        for (int i = 0; i < m_allSpawnSpeed.Length; i++)
        {
            m_allSpawnSpeed[i] = 1f;
        }
    }

    void Update()
    {
        if (!m_spawn) return;
        for (int i = 0; i < m_timers.Length; i++)
        {
            m_timers[i] += m_spawnSpeed[i] * m_allSpawnSpeed[i] * Time.deltaTime;
            if (m_timers[i] >= m_spawnTime[i])
            {
                m_spawnObjects[i].Spawn(m_spwanPos[m_count].position);
                m_count++;
                m_timers[i] = 0;
                if(m_count >= m_spwanPos.Length)
                {
                    m_count = 0;
                    PositionShuffle();
                }
            }
        }
    }
    void PositionShuffle()
    {
        for (int i = 0; i < m_spwanPos.Length; i++)
        {
            int r = Random.Range(0, m_spwanPos.Length);
            Transform p = m_spwanPos[i];
            m_spwanPos[i] = m_spwanPos[r];
            m_spwanPos[r] = p;
        }
    }
    void StopSpawn()
    {
        m_spawn = false;
        for (int i = 0; i < m_timers.Length; i++)
        {
            m_timers[i] = 0;
        }
        for (int i = 0; i < m_allSpawnSpeed.Length; i++)
        {
            m_allSpawnSpeed[i] = 1f;
        }
    }
    void StartSpawn()
    {
        m_spawn = true;
        m_count = 0;
        PositionShuffle();
    }
}

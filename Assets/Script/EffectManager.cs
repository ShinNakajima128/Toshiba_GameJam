using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectType
{
    Explosion,
}
/// <summary>
/// エフェクトを再生する
/// </summary>
public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance { get; private set; }
    [SerializeField] GameObject[] m_effectPrefabs;
    [SerializeField] Cinemachine.CinemachineImpulseSource m_source;
    bool m_shake;
    private void Awake()
    {
        Instance = this;
    }
    public void PlayEffect(EffectType type,Vector3 pos)
    {
        Instantiate(m_effectPrefabs[(int)type]).transform.position = pos;
    }
    public void PlayShake()
    {
        m_source.GenerateImpulse();
    }
    public void PlayShake(float time)
    {
        if (m_shake)
        {
            return;
        }
        StartCoroutine(Shake(time));
    }
    IEnumerator Shake(float time)
    {
        m_shake = true;
        float count = 0.5f;
        while (time > 0)
        {
            time -= Time.deltaTime;
            count += Time.deltaTime;
            if (count >= 0.5f)
            {
                m_source.GenerateImpulse();
                count = 0;
            }
            yield return new WaitForEndOfFrame();
        }
        m_shake = false;
    }
}

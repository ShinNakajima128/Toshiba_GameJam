using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Playerタグに衝突時空腹を回復し消滅
/// </summary>
public class HitRecovery : MonoBehaviour
{
    [Header("空腹回復量")]
    [SerializeField] int m_value = 20;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mouth")
        {
            GameManager.Instance.Recovery(m_value);
            Destroy(this.gameObject);
        }
    }
}

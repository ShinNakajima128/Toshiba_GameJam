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
            SoundManager.Instance.PlaySeByName("3_eat");
            GameManager.Instance.Recovery(m_value);
            EffectManager.Instance.ViewText(m_value * 10, this.transform.position, Color.green);
            EffectManager.Instance.PlayEffect(EffectType.ItemGet, this.transform.position);
            Destroy(this.gameObject);
        }
    }
}
